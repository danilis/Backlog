#pragma once

namespace Graph {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::DataVisualization::Charting::Chart^  chart1;
	protected: 

	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::Windows::Forms::DataVisualization::Charting::ChartArea^  chartArea1 = (gcnew System::Windows::Forms::DataVisualization::Charting::ChartArea());
			System::Windows::Forms::DataVisualization::Charting::Legend^  legend1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Legend());
			System::Windows::Forms::DataVisualization::Charting::Series^  series1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint1 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(0, 
				500));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint2 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(30, 
				0));
			System::Windows::Forms::DataVisualization::Charting::Series^  series2 = (gcnew System::Windows::Forms::DataVisualization::Charting::Series());
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint3 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(0, 
				500));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint4 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(3, 
				470));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint5 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(6, 
				400));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint6 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(9, 
				390));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint7 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(12, 
				330));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint8 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(15, 
				295));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint9 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(18, 
				295));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint10 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(21, 
				200));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint11 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(24, 
				170));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint12 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(27, 
				140));
			System::Windows::Forms::DataVisualization::Charting::DataPoint^  dataPoint13 = (gcnew System::Windows::Forms::DataVisualization::Charting::DataPoint(30, 
				50));
			this->chart1 = (gcnew System::Windows::Forms::DataVisualization::Charting::Chart());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->chart1))->BeginInit();
			this->SuspendLayout();
			// 
			// chart1
			// 
			chartArea1->Area3DStyle->Enable3D = true;
			chartArea1->Area3DStyle->LightStyle = System::Windows::Forms::DataVisualization::Charting::LightStyle::Realistic;
			chartArea1->Area3DStyle->PointDepth = 30;
			chartArea1->Area3DStyle->PointGapDepth = 30;
			chartArea1->Area3DStyle->Rotation = 10;
			chartArea1->Area3DStyle->WallWidth = 10;
			chartArea1->AxisX->LabelStyle->Interval = 1;
			chartArea1->AxisX->LabelStyle->IntervalOffset = 3;
			chartArea1->AxisX->LabelStyle->IntervalOffsetType = System::Windows::Forms::DataVisualization::Charting::DateTimeIntervalType::Number;
			chartArea1->AxisX->LabelStyle->IntervalType = System::Windows::Forms::DataVisualization::Charting::DateTimeIntervalType::Number;
			chartArea1->AxisX->Title = L"Days";
			chartArea1->AxisY->Interval = 40;
			chartArea1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(224)), 
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			chartArea1->Name = L"ChartArea1";
			this->chart1->ChartAreas->Add(chartArea1);
			legend1->Name = L"Legend1";
			this->chart1->Legends->Add(legend1);
			this->chart1->Location = System::Drawing::Point(-1, 0);
			this->chart1->Name = L"chart1";
			this->chart1->PaletteCustomColors = gcnew cli::array< System::Drawing::Color >(2) {System::Drawing::Color::Cyan, System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), 
				static_cast<System::Int32>(static_cast<System::Byte>(0)), static_cast<System::Int32>(static_cast<System::Byte>(0)))};
			series1->ChartArea = L"ChartArea1";
			series1->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series1->Legend = L"Legend1";
			series1->Name = L"Expected Progress";
			series1->Points->Add(dataPoint1);
			series1->Points->Add(dataPoint2);
			series1->XValueType = System::Windows::Forms::DataVisualization::Charting::ChartValueType::Int32;
			series1->YValueType = System::Windows::Forms::DataVisualization::Charting::ChartValueType::Int32;
			series2->ChartArea = L"ChartArea1";
			series2->ChartType = System::Windows::Forms::DataVisualization::Charting::SeriesChartType::Line;
			series2->Legend = L"Legend1";
			series2->Name = L"Real progress";
			dataPoint13->BackGradientStyle = System::Windows::Forms::DataVisualization::Charting::GradientStyle::None;
			series2->Points->Add(dataPoint3);
			series2->Points->Add(dataPoint4);
			series2->Points->Add(dataPoint5);
			series2->Points->Add(dataPoint6);
			series2->Points->Add(dataPoint7);
			series2->Points->Add(dataPoint8);
			series2->Points->Add(dataPoint9);
			series2->Points->Add(dataPoint10);
			series2->Points->Add(dataPoint11);
			series2->Points->Add(dataPoint12);
			series2->Points->Add(dataPoint13);
			series2->XValueType = System::Windows::Forms::DataVisualization::Charting::ChartValueType::Int32;
			series2->YValueType = System::Windows::Forms::DataVisualization::Charting::ChartValueType::Int32;
			this->chart1->Series->Add(series1);
			this->chart1->Series->Add(series2);
			this->chart1->Size = System::Drawing::Size(810, 498);
			this->chart1->TabIndex = 0;
			this->chart1->Text = L"chart1";
			this->chart1->Click += gcnew System::EventHandler(this, &Form1::Form1_Load);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::White;
			this->ClientSize = System::Drawing::Size(809, 498);
			this->Controls->Add(this->chart1);
			this->Name = L"Form1";
			this->Text = L"Graph of progress";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->chart1))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
			 }

	};
}

