/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 12.01.2020
 * Время: 13:15
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace PaLoSi
{
	/// <summary>
	/// Description of dialog.
	/// </summary>
	public partial class dialog : Form
	{

public Dictionary<int, string> WhyPress =new Dictionary<int, string> ();	
private Button START=new Button();
private Button CANSEL=new Button();
private Label[] LABEL=new Label[100];
private Label Label=new Label();
private CheckBox[] NEW=new CheckBox[100];
private CheckBox[] RESUME=new CheckBox[100];
private CheckBox[] ERROR=new CheckBox[100];

public dialog()	{	InitializeComponent();	}
		
public dialog(MainForm f)	{
	InitializeComponent();
	frm=f;
	START.Text="Start";
	START.Size=new Size(70,30);
	START.Click+=Start;
	this.Controls.Add(START);

	CANSEL.Text="Close";
	CANSEL.Size=new Size(70,30);
	CANSEL.Click+=Cansel;
	this.Controls.Add(CANSEL);
}

		
private MainForm frm;
private Work Wrk=new Work();
private int cout=0;

public void AddInfo(string name, int j,string NameThreading){
	Label.Text="The download has already been made, select next steps.";
	Label.Size=new Size(400,20);
	Label.Location=new Point(10,10);
	this.Controls.Add(Label);	
	
	RESUME[j]=new CheckBox();
	RESUME[j].Text="Continue";
	RESUME[j].Size=new Size(120,20);
	RESUME[j].Location=new Point(10,20*j+30);
	RESUME[j].Tag=j.ToString();
	RESUME[j].Click+=Resume;
	this.Controls.Add(RESUME[j]);
	
	NEW[j]=new CheckBox();
	NEW[j].Text="Start over";
	NEW[j].Size=new Size(130,20);
	NEW[j].Location=new Point(140,20*j+30);
	NEW[j].Tag=j.ToString();
	NEW[j].Click+=New;
	this.Controls.Add(NEW[j]);
	
	ERROR[j]=new CheckBox();
	ERROR[j].Text="Recheck errors";
	ERROR[j].Size=new Size(200,20);
	ERROR[j].Location=new Point(280,20*j+30);
	ERROR[j].Tag=j.ToString();
	ERROR[j].Click+=Erorr;
	this.Controls.Add(ERROR[j]);
	
	//WhyPress.Add(20*j+30,name);

	LABEL[j]=new Label();
	LABEL[j].Text=name;
	LABEL[j].Size=new Size(400,20);
	LABEL[j].Tag=NameThreading;
	LABEL[j].ForeColor = Color.Black;
	LABEL[j].Location=new Point(480,20*j+30);
	this.Controls.Add(LABEL[j]);
	
	CANSEL.Location=new Point(60,20*j+50);
	START.Location=new Point(160,20*j+50);
	cout=j;
	
}
public void  Erorr(object sender, EventArgs e){
	CheckBox chckbx=(CheckBox)sender;
	int j=Convert.ToInt16(chckbx.Tag.ToString());
	if(ERROR[j].Checked) {
		NEW[j].Checked=false;
		RESUME[j].Checked=true;
		ERROR[j].Checked=true;
	}
}
public void Resume(object sender, EventArgs e){
	CheckBox chckbx=(CheckBox)sender;
	int j=Convert.ToInt16(chckbx.Tag.ToString());
	if(!RESUME[j].Checked) {
		RESUME[j].Checked=false;
		ERROR[j].Checked=false;
	}
	else {
		NEW[j].Checked=false;
		RESUME[j].Checked=true;
		
	}
}

public void New(object sender, EventArgs e){
	CheckBox chckbx=(CheckBox)sender;
	int j=Convert.ToInt16(chckbx.Tag.ToString());
	if(!NEW[j].Checked) NEW[j].Checked=false;
	else {
		NEW[j].Checked=true;
		RESUME[j].Checked=false;
		ERROR[j].Checked=false;
	}
}
	
	
public void Start(object sender, EventArgs e){
	cout++;
	List<string> NW=new List<string>();
	List<string> RSM=new List<string>();
	List<string> RRR=new List<string>();
	for(int i=0;i<cout;i++){
		if(NEW[i].Checked) NW.Add(LABEL[i].Tag.ToString());
		if(RESUME[i].Checked) RSM.Add(LABEL[i].Tag.ToString());
		if(ERROR[i].Checked) RRR.Add(LABEL[i].Tag.ToString());
		
	}
	frm.ResumeLoad(NW,RSM,RRR);
	this.Close();
}

public void Cansel(object sender, EventArgs e){
	this.Close();
		                    
}
void DialogFormClosed(object sender, FormClosedEventArgs e)	{
	frm.dial=0;
}



	}
}
