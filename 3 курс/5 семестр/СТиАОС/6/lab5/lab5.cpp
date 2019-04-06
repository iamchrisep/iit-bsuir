#include <windows.h>
#include <tchar.h>
#include <strsafe.h>
#include <stdio.h>
#include <vector>
#include <unistd.h>
#include <iostream>
#include <iomanip>
#include <fstream>
#include <string.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <dirent.h>
#include <map>

#define BUF_SIZE 255

using namespace std;

DWORD WINAPI SeeBytes( LPVOID lpParam );
void ErrorHandler(LPTSTR lpszFunction);

typedef struct MyData {
    string url;
} MYDATA, *PMYDATA;

bool ArrayEqual (char*  a, char* b) {
    for (int i = 0; i < sizeof a; i++)
    {
        if (a[i] != b[i]) return false;
    }
    return true;
}



int isFile(const char *path)
{
    struct stat path_stat;
    stat(path, &path_stat);
    return S_ISREG(path_stat.st_mode);
}

DWORD WINAPI SeeBytes( LPVOID lpParam ) 
{ 
    HANDLE hStdout;
    PMYDATA data;

    TCHAR msgBuf[BUF_SIZE];
    size_t cchStringSize;
    DWORD dwChars;

    // Make sure there is a console to receive output results. 

    hStdout = GetStdHandle(STD_OUTPUT_HANDLE);
    if( hStdout == INVALID_HANDLE_VALUE )
        return 1;

    // Cast the parameter to the correct data type.
    // The pointer is known to be valid because 
    // it was checked for NULL before the thread was created.
 
    data = (PMYDATA)lpParam;

	ifstream inputFile(data->url.c_str(), ifstream::binary);
    char arrayKey[4] = {'r','d','c','t'};
    char arrayTemp[sizeof arrayKey];
    inputFile.seekg(0, inputFile.end);
    int length = inputFile.tellg();
    int countEquals = 0;
    for (int i = 0; i < length - sizeof arrayTemp + 1; i++) {
        inputFile.seekg(i, inputFile.beg);
        inputFile.read((char*)&arrayTemp, sizeof arrayTemp);
        countEquals += (int) ArrayEqual(arrayKey, arrayTemp);
    }
    inputFile.close();
	
    // Print the parameter values using thread-safe functions.
	cout << "PID: " << GetCurrentThreadId() << "\t File: " << data->url <<"\t\t  Bytes: " << length << "\t Equals: " << countEquals << "\n";
    /*StringCchPrintf(msgBuf, BUF_SIZE, TEXT("PID: %d\t File: %s\t\t  Bytes: %d\t Equals: %d\n"), 
        1, data->url, length, countEquals); 
    StringCchLength(msgBuf, BUF_SIZE, &cchStringSize);
    WriteConsole(hStdout, msgBuf, (DWORD)cchStringSize, &dwChars, NULL);*/

    return 0; 
} 

int main(int argc, char* argv[])
{
    DIR *dir;
    struct dirent *entry;
    struct stat statbuf;
    string url = "d:\\st5";
    vector<string> files;
	
	int maxThreadCount;
	cout << "Enter max threads count: ";
	cin >> maxThreadCount;
	
    dir = opendir(url.c_str());

    while ( (entry = readdir(dir)) != NULL) {
        if (isFile(entry->d_name)) {
                files.push_back(entry->d_name);
        }
    };
    closedir(dir);
	
	cout << "Files found: " << files.size() << endl;

    int current = 0;
	
	PMYDATA pDataArray[files.size()];
	DWORD   dwThreadIdArray[files.size()];
    HANDLE  hThreadArray[files.size()];	
	
    while(current < files.size()) {
		// Allocate memory for thread data.

        pDataArray[current] = (PMYDATA) HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY,
                sizeof(MYDATA));

        if( pDataArray[current] == NULL )
        {
           // If the array allocation fails, the system is out of memory
           // so there is no point in trying to print an error message.
           // Just terminate execution.
            ExitProcess(2);
        }

        // Generate unique data for each thread to work with.

        pDataArray[current]->url = files[current];

        // Create the thread to begin execution on its own.

        hThreadArray[current] = CreateThread( 
            NULL,                   // default security attributes
            0,                      // use default stack size  
            SeeBytes,       // thread function name
            pDataArray[current],          // argument to thread function 
            0,                      // use default creation flags 
            &dwThreadIdArray[current]);   // returns the thread identifier 


        // Check the return value for success.
        // If CreateThread fails, terminate execution. 
        // This will automatically clean up threads and memory. 

        if (hThreadArray[current] == NULL) 
        {
           ErrorHandler(TEXT("CreateThread"));
           ExitProcess(3);
        }
        
		current++;
    }
	
	// Wait until all threads have terminated.
	
	WaitForMultipleObjects(files.size(), hThreadArray, TRUE, INFINITE);
	
	// Close all thread handles and free memory allocations.

    for(int i=0; i<files.size(); i++)
    {
        CloseHandle(hThreadArray[i]);
        if(pDataArray[i] != NULL)
        {
            HeapFree(GetProcessHeap(), 0, pDataArray[i]);
            pDataArray[i] = NULL;    // Ensure address is not reused.
        }
    }
	
	return 0;
}

void ErrorHandler(LPTSTR lpszFunction) 
{ 
    // Retrieve the system error message for the last-error code.

    LPVOID lpMsgBuf;
    LPVOID lpDisplayBuf;
    DWORD dw = GetLastError(); 

    FormatMessage(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | 
        FORMAT_MESSAGE_FROM_SYSTEM |
        FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL,
        dw,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPTSTR) &lpMsgBuf,
        0, NULL );

    // Display the error message.

    lpDisplayBuf = (LPVOID)LocalAlloc(LMEM_ZEROINIT, 
        (lstrlen((LPCTSTR) lpMsgBuf) + lstrlen((LPCTSTR) lpszFunction) + 40) * sizeof(TCHAR)); 
    StringCchPrintf((LPTSTR)lpDisplayBuf, 
        LocalSize(lpDisplayBuf) / sizeof(TCHAR),
        TEXT("%s failed with error %d: %s"), 
        lpszFunction, dw, lpMsgBuf); 
    MessageBox(NULL, (LPCTSTR) lpDisplayBuf, TEXT("Error"), MB_OK); 

    // Free error-handling buffer allocations.

    LocalFree(lpMsgBuf);
    LocalFree(lpDisplayBuf);
}
