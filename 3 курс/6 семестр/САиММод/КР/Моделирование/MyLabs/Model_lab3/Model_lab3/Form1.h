#pragma once
#include <string>
using namespace std;

#define QuantStates 16

namespace Model_lab3 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
    using namespace System::Linq;
    using namespace System::Text;

	/// <summary>
	/// Сводка для Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}
	private: System::Windows::Forms::TextBox^  tbPerehod;
	private: System::Windows::Forms::TextBox^  tbQuant;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::GroupBox^  groupBox1;
	public: 

		
	private: System::Windows::Forms::TextBox^  tbWc;
	public: 
	private: System::Windows::Forms::TextBox^  tbPbl;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label2;
			 
			 string **pArr;
			 long Rprev;

		void InitArray(void){
			string arr1[] = {"0.75:0000", "1:1100"};
			string arr2[] = {"0.26:0000", "0.75:0001", "0.84:1100", "1:1101"};
			string arr3[] = {"0.26:0001", "0.75:0011", "0.84:1101", "1:1111"};
			string arr4[] = {"0,26:0011", "0.75:0021", "0.84:1111", "1:1121"};
			string arr5[] = {"0.23:0001", "0.76:0100", "0.84:1101", "1:2100"};
			string arr6[] = {"0.08:0001", "0.23:0011", "0.41:0100", "0.74:0101", "0.77:1101", "0.82:1111", "0.89:2100", "1:2101"};
			string arr7[] = {"0.08:0011", "0.23:0021", "0.41:0101", "0.74:0111", "0.77:1111", "0.82:1121", "0.89:2101", "1:2111"};
			string arr8[] = {"0.08:0021", "0.26:0111", "0.60:0121", "0.63:1121", "0.69:2111", "1:2121"};
			string arr9[] = {"0.23:0001", "0.76:0100", "0.84:1101", "1:2100"};
			string arr10[] = {"0.08:0001", "0.23:0011", "0.41:0100", "0.75:0101", "0.78:1101", "0.83:1111", "0.89:2100", "1:2101"};
			string arr11[] = {"0.08:0011", "0.23:0021", "0.41:0101", "0.75:0111", "0,78:1111", "0.83:1121", "0.89:2101", "1:2111"};
			string arr12[] = {"0.08:0021", "0.23:0111", "0.41:0121", "0,75:1121", "0.89:2111", "1:2121"};
			string arr13[] = {"0.23:0101", "0.93:2100", "1:2101"};
			string arr14[] = {"0.08:0101", "0.23:0111", "0.48:2100", "0.95:2101", "1:2111"};
			string arr15[] = {"0.08:0111", "0.23:0121", "0.48:2101", "0.95:2111", "1:2121"};
			string arr16[] = {"0.08:0121", "0.33:2111", "1:2121"};

			pArr = new string*[16];
			pArr[0] = arr1;
			pArr[1] = arr2;
			pArr[2] = arr3;
			pArr[3] = arr4;
			pArr[4] = arr5;
			pArr[5] = arr6;
			pArr[6] = arr7;
			pArr[7] = arr8;
			pArr[8] = arr9;
			pArr[9] = arr10;
			pArr[10] = arr11;
		    pArr[11] = arr12;
			pArr[12] = arr13;
			pArr[13] = arr14;
			pArr[14] = arr15;
			pArr[15] = arr16;

			string my=pArr[10][2].substr(1,1);
			const char* a = pArr[10][2].c_str();

		}

		int GetCurrentStateNum(string CurrentState){
			int CurrentStateNum;
			 
			if ( strcmp( CurrentState.c_str(), "0000" ) == 0){
				CurrentStateNum = 0;
			}
			if ( strcmp( CurrentState.c_str(), "0001" ) == 0){
				CurrentStateNum = 1;
			}
			if ( strcmp( CurrentState.c_str(), "0011" ) == 0){
				CurrentStateNum = 2;
			}
			if ( strcmp( CurrentState.c_str(), "0021" ) == 0){
				CurrentStateNum = 3;
			}
			if ( strcmp( CurrentState.c_str(), "0100" ) == 0){
				CurrentStateNum = 4;
			}
			if ( strcmp( CurrentState.c_str(), "0101" ) == 0){
				CurrentStateNum = 5;
			}
			if ( strcmp( CurrentState.c_str(), "0111" ) == 0){
				CurrentStateNum = 6;
			}
			if ( strcmp( CurrentState.c_str(), "0121" ) == 0){
				CurrentStateNum = 7;
			}
			if ( strcmp( CurrentState.c_str(), "1100" ) == 0){
				CurrentStateNum = 8;
			}
			if ( strcmp( CurrentState.c_str(), "1101" ) == 0){
				CurrentStateNum = 9;
			}
			if ( strcmp( CurrentState.c_str(), "1111" ) == 0){
				CurrentStateNum = 10;
			}
			if ( strcmp( CurrentState.c_str(), "1121" ) == 0){
				CurrentStateNum = 11;
			}
			if ( strcmp( CurrentState.c_str(), "2100" ) == 0){
				CurrentStateNum = 12;
			}
			if ( strcmp( CurrentState.c_str(), "2101" ) == 0){
				CurrentStateNum = 13;
			}
			if ( strcmp( CurrentState.c_str(), "2111" ) == 0){
				CurrentStateNum = 14;
			}
			if ( strcmp( CurrentState.c_str(), "2121" ) == 0){
				CurrentStateNum = 15;
			}

			return CurrentStateNum;
		}

		double GetLehmerRand(void){
			int m = 10000, a = 1867;
			Rprev = (a * Rprev) % m;
            return (double)Rprev / m;
		}
	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}


	protected: 
	private: System::Windows::Forms::Button^  btnStart;

	private:
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->btnStart = (gcnew System::Windows::Forms::Button());
			this->tbPerehod = (gcnew System::Windows::Forms::TextBox());
			this->tbQuant = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->tbWc = (gcnew System::Windows::Forms::TextBox());
			this->tbPbl = (gcnew System::Windows::Forms::TextBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->groupBox1->SuspendLayout();
			this->SuspendLayout();
			// 
			// btnStart
			// 
			this->btnStart->BackColor = System::Drawing::Color::Lime;
			this->btnStart->Location = System::Drawing::Point(16, 323);
			this->btnStart->Name = L"btnStart";
			this->btnStart->Size = System::Drawing::Size(260, 23);
			this->btnStart->TabIndex = 1;
			this->btnStart->Text = L"Моделировать";
			this->btnStart->UseVisualStyleBackColor = false;
			this->btnStart->Click += gcnew System::EventHandler(this, &Form1::btnStart_Click);
			// 
			// tbPerehod
			// 
			this->tbPerehod->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->tbPerehod->Location = System::Drawing::Point(12, 12);
			this->tbPerehod->Multiline = true;
			this->tbPerehod->Name = L"tbPerehod";
			this->tbPerehod->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->tbPerehod->Size = System::Drawing::Size(211, 305);
			this->tbPerehod->TabIndex = 2;
			// 
			// tbQuant
			// 
			this->tbQuant->Location = System::Drawing::Point(344, 12);
			this->tbQuant->Name = L"tbQuant";
			this->tbQuant->Size = System::Drawing::Size(43, 20);
			this->tbQuant->TabIndex = 3;
			this->tbQuant->Text = L"20";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(262, 15);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(76, 13);
			this->label1->TabIndex = 4;
			this->label1->Text = L"Кол-во чисел:";
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->tbWc);
			this->groupBox1->Controls->Add(this->tbPbl);
			this->groupBox1->Controls->Add(this->label3);
			this->groupBox1->Controls->Add(this->label2);
			this->groupBox1->Location = System::Drawing::Point(229, 226);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(152, 80);
			this->groupBox1->TabIndex = 5;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Вычислить";
			this->groupBox1->Visible = false;
			// 
			// tbWc
			// 
			this->tbWc->Location = System::Drawing::Point(84, 49);
			this->tbWc->Name = L"tbWc";
			this->tbWc->Size = System::Drawing::Size(54, 20);
			this->tbWc->TabIndex = 3;
			this->tbWc->Text = L"2.75";
			// 
			// tbPbl
			// 
			this->tbPbl->Location = System::Drawing::Point(84, 23);
			this->tbPbl->Name = L"tbPbl";
			this->tbPbl->Size = System::Drawing::Size(54, 20);
			this->tbPbl->TabIndex = 2;
			this->tbPbl->Text = L"0.27949";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(27, 52);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(27, 13);
			this->label3->TabIndex = 1;
			this->label3->Text = L"Wc:";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(27, 26);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(29, 13);
			this->label2->TabIndex = 0;
			this->label2->Text = L"Pбл:";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(399, 358);
			this->Controls->Add(this->groupBox1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->tbQuant);
			this->Controls->Add(this->tbPerehod);
			this->Controls->Add(this->btnStart);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
			this->Name = L"Form1";
			this->Text = L"Лаба №3(1+2)";
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void btnStart_Click(System::Object^  sender, System::EventArgs^  e) {
				 tbPerehod->Text = "";
				 groupBox1->Visible = false;

				 //InitArray();
				string arr1[] = {"0.75:0000", "1:1100"};
				string arr2[] = {"0.26:0000", "0.75:0001", "0.84:1100", "1:1101"};
				string arr3[] = {"0.26:0001", "0.75:0011", "0.84:1101", "1:1111"};
				string arr4[] = {"0,26:0011", "0.75:0021", "0.84:1111", "1:1121"};
				string arr5[] = {"0.23:0001", "0.76:0100", "0.84:1101", "1:2100"};
				string arr6[] = {"0.08:0001", "0.23:0011", "0.41:0100", "0.74:0101", "0.77:1101", "0.82:1111", "0.89:2100", "1:2101"};
				string arr7[] = {"0.08:0011", "0.23:0021", "0.41:0101", "0.74:0111", "0.77:1111", "0.82:1121", "0.89:2101", "1:2111"};
				string arr8[] = {"0.08:0021", "0.26:0111", "0.60:0121", "0.63:1121", "0.69:2111", "1:2121"};
				string arr9[] = {"0.23:0001", "0.76:0100", "0.84:1101", "1:2100"};
				string arr10[] = {"0.08:0001", "0.23:0011", "0.41:0100", "0.75:0101", "0.78:1101", "0.83:1111", "0.89:2100", "1:2101"};
				string arr11[] = {"0.08:0011", "0.23:0021", "0.41:0101", "0.75:0111", "0,78:1111", "0.83:1121", "0.89:2101", "1:2111"};
				string arr12[] = {"0.08:0021", "0.23:0111", "0.41:0121", "0,75:1121", "0.89:2111", "1:2121"};
				string arr13[] = {"0.23:0101", "0.93:2100", "1:2101"};
				string arr14[] = {"0.08:0101", "0.23:0111", "0.48:2100", "0.95:2101", "1:2111"};
				string arr15[] = {"0.08:0111", "0.23:0121", "0.48:2101", "0.95:2111", "1:2121"};
				string arr16[] = {"0.08:0121", "0.33:2111", "1:2121"};

				pArr = new string*[16];
				pArr[0] = arr1;
				pArr[1] = arr2;
				pArr[2] = arr3;
				pArr[3] = arr4;
				pArr[4] = arr5;
				pArr[5] = arr6;
				pArr[6] = arr7;
				pArr[7] = arr8;
				pArr[8] = arr9;
				pArr[9] = arr10;
				pArr[10] = arr11;
				pArr[11] = arr12;
				pArr[12] = arr13;
				pArr[13] = arr14;
				pArr[14] = arr15;
				pArr[15] = arr16;				 
	
				 double X;
				 string p1, p2;		

				 string CurrentState = "0000";
				 int CurrentStateNum;
				 int q = Convert::ToInt32(tbQuant->Text);
				 Rprev = 2978;

				 for(int ii = 0; ii < q; ii++){
					 X = Math::Round(GetLehmerRand(), 4);					 
				     CurrentStateNum = GetCurrentStateNum(CurrentState);
					 for(int j = 0; j < QuantStates - 1; j++){
						 p1 = pArr[CurrentStateNum][j].substr(0, pArr[CurrentStateNum][j].find(":"));
						 p2 = pArr[CurrentStateNum][j].substr(pArr[CurrentStateNum][j].find(":")+1, 4);


						 if (stod(p1) > X){
							CurrentState = p2;							
							tbPerehod->Text = tbPerehod->Text + X + "  -  " +  gcnew String((char*)CurrentState.c_str()) + "\r\n";
							break;
						 }						 
					 }
				 }	
				 groupBox1->Visible = true;
			 }
	};
}

