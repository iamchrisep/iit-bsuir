#include <stdio.h>
#include <unistd.h>
#include <iostream>
#include <string>
#include <string.h>
#include <sstream>
#include<vector>
#include <sys/types.h>
#include <sys/wait.h>

using namespace std;

int main() {

	int success_status = 0;
	bool is_main = true;
	string command ("");

	getline (cin, command);
		
	while (command.compare("exit") != 0) {		

		char *command_name = new char[256];
		char **command_args = new char*[256];
		
		
		istringstream iss(command);
		string token;
		int i=0;
		
		while (getline(iss, token, ' '))
		{
			if (i == 0) {
				strcpy(command_name, token.c_str());
				command_args[i] = new char[256];
				strcpy(command_args[i], "");
			} else {				
				command_args[i] = new char[256];
				strcpy(command_args[i], token.c_str());
			}
			
			i++;
		}
		
		//fork process
		pid_t PID;
		PID = fork();		
		
		if (PID == 0) {
			//child process, do the job
			if (i > 1) {
				execvp(command_name, command_args);
			} else {
				execlp(command_name, "", NULL);
			}
			
			return 0;
		}
		
		getline (cin, command);
		
		delete[] command_name;
	}
	
	wait(NULL);
	
	return 0;
}