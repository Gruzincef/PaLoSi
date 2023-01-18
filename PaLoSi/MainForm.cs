using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace PaLoSi
{
	public partial class MainForm : Form
	{
	dialog dlg;
	Save sv=new Save();
	public static MainForm frm;
	public int dial=0;
	public int WothLoad;
	StartLoad StrtLd=new StartLoad();
	Threaders Thrdrs=new Threaders();
	Records Rcrd=new Records();
	private int start;
	private int stop;
	private int CountRow;
	private int position;
	private int NumberOpen;
	public static string appdata;
	private const string AppMutexName = "PaLoSi";
	
	public MainForm(){
		 using (Mutex mutex = new Mutex(false, AppMutexName))  {
    		bool Running = !mutex.WaitOne(0, false);
     		if(!Running)  {
				InitializeComponent();
				DialogResult dialogresult;
				WothLoad=0;
				appdata =  Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\";
				if(!Directory.Exists(appdata)) Directory.CreateDirectory(appdata);
			 	if(frm==null) frm=this;
				MenegerEvent ME=MenegerEvent.getInstance();
				ME.Event_Messeg+=new MenegerEvent.OperationDelegate(Messege);
				LoadConfig();
				resize();
				start=0;
				stop=10;
				CountRow=0;
				position=0;
				if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin"))
					dialogresult=MessageBox.Show("The program is not activated!", "The program is not activated!", MessageBoxButtons.OK);
				ButtonStart.Click+=ButtonStrt;
				ButtonNext.Click+=ButtonNxt;
				ButtonEnd.Click+=Buttonnd;
				ButtonBack.Click+=ButtonBac;
				ButtonEnter.Click+=ButtonNter;
    		}	else {
        		MessageBox.Show("Программа уже запущена");
      }
	}
}

//public static int CounProject=100;
public static int CounView=10;
private CheckBox[] checkedProject=new CheckBox[CounView];
public void ndLd(MessegTask mess){
	if(progressBar1.Value==100)progressBar1.Value=0;
	progressBar1.Value++;
	DateTime date1 = new DateTime();
	date1=DateTime.Now;
		if(mess.TYPE==EVENT_TYPE.FIRSTSTART){
			progressBar1.Value=0;
		}
		if(mess.TYPE==EVENT_TYPE.END){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Green;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
			if(Work.StrtLd.ContainsKey(mess.NAMEPROJECT))
				File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Download completed. Downloaded. "+Work.StrtLd[mess.NAMEPROJECT].CountLoad.ToString()+"\r\n", Encoding.Unicode);
			else File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Download completed. \r\n", Encoding.Unicode); 
		}
		if(mess.TYPE==EVENT_TYPE.START){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Orange;
			labelMessage.Text=mess.MESS;
			File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Starting the download. \r\n", Encoding.Unicode);
		}
		if(mess.TYPE==EVENT_TYPE.STARTLOAD){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Orange;
			labelMessage.Text=mess.MESS;
		}
		if(mess.TYPE==EVENT_TYPE.NEW){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Orange;
			labelMessage.Text=mess.MESS;
			File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" New download. \r\n", Encoding.Unicode);
		}
			if(mess.TYPE==EVENT_TYPE.RESUME){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Orange;
			labelMessage.Text=mess.MESS;
			File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Download continued. \r\n", Encoding.Unicode);
		}
		if(mess.TYPE==EVENT_TYPE.STOP){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Red;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
			if(Work.StrtLd.ContainsKey(mess.NAMEPROJECT))
				File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+"  Download stopped. Processed. "+Work.StrtLd[mess.NAMEPROJECT].CountLoad.ToString()+" pages\r\n", Encoding.Unicode);
			else File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Download stopped. \r\n", Encoding.Unicode);
		}
		if(mess.TYPE==EVENT_TYPE.SAVE){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Blue;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
		}
		if(mess.TYPE==EVENT_TYPE.ENDSAVE){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Gray;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
			File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Saving completed. \r\n", Encoding.Unicode);
		}
		if(mess.TYPE==EVENT_TYPE.ERRORLOAD){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Gray;
			labelMessage.Text=mess.MESS;
		}
		if(mess.TYPE==EVENT_TYPE.ERROR){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Gray;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
			File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Loading error. You may not be connected to the Internet. The proxy server or site address is not specified correctly. "+"\r\n", Encoding.Unicode);
		}
		if(mess.TYPE==EVENT_TYPE.STOPLOAD){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Gray;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
			File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Download stopped. "+"\r\n", Encoding.Unicode);
		}
		if(mess.TYPE==EVENT_TYPE.ENDLOAD){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Gray;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
			if(Work.StrtLd.ContainsKey(mess.NAMEPROJECT))			
				File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Download completed. Processed "+Work.StrtLd[mess.NAMEPROJECT].CountLoad.ToString()+"  pages\r\n", Encoding.Unicode);
			else File.AppendAllText(appdata+"info\\"+mess.NAMETHREAING+"\\log.txt", "["+date1.ToString()+"] "+mess.NAMEPROJECT+" Download completed "+"\r\n", Encoding.Unicode);
		}
		if(mess.TYPE==EVENT_TYPE.ERRORLOADFILE){
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) checkedProject[i].ForeColor=Color.Gray;
			labelMessage.Text=mess.MESS;
			progressBar1.Value=0;
		}
		if(mess.TYPE==EVENT_TYPE.EXISTS){
			progressBar1.Value=0;
			if(dial==0){
				dlg= new dialog(this);
				dlg.Show(this);
			}
			int intproject=0;
			for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Text==mess.NAMEPROJECT) intproject=i;
			dlg.AddInfo(mess.NAMEPROJECT,dial,mess.NAMETHREAING);
			dial++;
	}
	if(mess.TYPE==EVENT_TYPE.MESSEG) labelMessage.Text=mess.MESS;
}


public void Messege(MessegTask mess){
	if(IsHandleCreated){
		IAsyncResult IA=this.BeginInvoke((MethodInvoker)(()=>this.ndLd(mess)));		
		this.EndInvoke(IA);
	}
}

public void QueryForm(EVENT_TYPE Event_Type, object messeg){
	DialogResult dialogresult=MessageBox.Show(messeg.ToString(), "Confirm the deletion?", MessageBoxButtons.YesNo);
}
		

public int checkedListProject=-1;
void MainFormResize(object sender, EventArgs e){
	resize();
	if(this.WindowState==FormWindowState.Minimized) hiden();
		
}
public void resize(){
	//Размер прогресс бар
	progressBar1.Size=new Size(this.Size.Width-40,progressBar1.Size.Height);
	//Позиция прогресс бар
	progressBar1.Location=new Point(10,this.Size.Height-progressBar1.Size.Height-40);
	//Размер labelMessage
	labelMessage.Size=new Size(this.Size.Width-40,labelMessage.Size.Height);
	//Позиция labelMessage
	labelMessage.Location=new Point(10,this.Size.Height-labelMessage.Size.Height-progressBar1.Size.Height-40);			
	//Размер меню
	menuStrip1.Size=new Size(this.Size.Width-40,menuStrip1.Size.Height-40);
	//Позиция меню
	menuStrip1.Location=new Point(10,10);			
	//Размер checkedListBoxSite
	panel1.Size=new Size(panel1.Size.Width,labelMessage.Location.Y-40);
	//Позиция checkedListBoxSite
	panel1.Location=new Point(10,menuStrip1.Size.Height+10);			
	//Размер tabControl1
	tabControl1.Size=new Size(this.Size.Width-panel1.Size.Width-40,panel1.Size.Height);
	//Позиция tabControl1
	tabControl1.Location=new Point(panel1.Size.Width+20,panel1.Location.Y);	
	LogrichTextBox1.Size=new Size(this.Size.Width-panel1.Size.Width-50,panel1.Size.Height-30);
	LogrichTextBox1.Location=new Point(panel1.Location.X-10,panel1.Location.Y-30);	
	
	for(int i=0;i<CounView;i++)
		if(ViewInfo[i]!=null) ViewInfo[i].Size=new Size(this.Size.Width-panel1.Size.Width-70,100);
}
void AddToolStripMenuItemClick(object sender, EventArgs e){
	checkedListProject=-1;
	FormConfiguration frm=new FormConfiguration("",this);
	frm.Show(this);
}



public void LoadConfig(){
	this.panel1.Controls.Clear();
	List<string>s=ListSites.LoadConfignameThreading();
for(int i=0;i<s.Count;i++){
		checkedProject[i]=new CheckBox();
		checkedProject[i].Text=ListSites.listSites[s[i]].nameProject;
		checkedProject[i].Location= new System.Drawing.Point(6, 15+25*i);
		checkedProject[i].Size= new Size(230,21);
		checkedProject[i].Tag=s[i].ToString();
		checkedProject[i].Click+=LoadLog;
		panel1.Controls.Add(checkedProject[i]);
		EVENT_TYPE et;
		et=Work.Wrk.GetEventLoad(s[i].ToString());
		if(et==EVENT_TYPE.END)       checkedProject[i].ForeColor=Color.Green;
		else if(et==EVENT_TYPE.START)     checkedProject[i].ForeColor=Color.Orange;
		else if(et==EVENT_TYPE.STARTLOAD) checkedProject[i].ForeColor=Color.Orange;
		else if(et==EVENT_TYPE.NEW)       checkedProject[i].ForeColor=Color.Orange;
		else if(et==EVENT_TYPE.RESUME)    checkedProject[i].ForeColor=Color.Orange;
		else if(et==EVENT_TYPE.STOP)      checkedProject[i].ForeColor=Color.Red;
		else if(et==EVENT_TYPE.SAVE)      checkedProject[i].ForeColor=Color.Blue;
		else if(et==EVENT_TYPE.ENDSAVE)   checkedProject[i].ForeColor=Color.Gray;
		else if(et==EVENT_TYPE.ERRORLOAD) checkedProject[i].ForeColor=Color.Gray;
		else if(et==EVENT_TYPE.STOPLOAD)  checkedProject[i].ForeColor=Color.Gray;
		else if(et==EVENT_TYPE.ENDLOAD)   checkedProject[i].ForeColor=Color.Gray;

		
	}
	frm.Activate();
}
public void LoadLog(object sender, EventArgs e){
	LogrichTextBox1.Clear();
	start=0;
	stop=10;
	position=0;
	LoadRecords(start,stop);
	CheckBox chckbx=(CheckBox)sender;
	string nameThreading=chckbx.Tag.ToString();
	if(File.Exists(appdata+"info\\"+nameThreading+"\\log.txt"))
		LogrichTextBox1.Text=File.ReadAllText(appdata+"info\\"+nameThreading+"\\log.txt", Encoding.Unicode);
}

void DeleteToolStripMenuItem1Click(object sender, EventArgs e){
DialogResult dialogresult=MessageBox.Show("Confirm the deletion?", "Confirm the deletion?", MessageBoxButtons.YesNo);
	if(dialogresult==DialogResult.Yes){
	for(int i=panel1.Controls.Count-1;i>-1;i--){
		if((checkedProject[i].Checked)&&(!Work.Wrk.StatusThread(checkedProject[i].Tag.ToString()))) {
			Work.Wrk.DeleteProject(checkedProject[i].Tag.ToString());
			ListSites.listSites.Remove(checkedProject[i].Tag.ToString());
		}
	}
	LoadConfig();
}
}
void UpdateToolStripMenuItemClick(object sender, EventArgs e){
	checkedListProject=-1;
	for(int i=0;i<panel1.Controls.Count;i++){
		if((checkedProject[i].Checked)&&(!Work.Wrk.StatusThread(checkedProject[i].Tag.ToString()))) {
			checkedListProject=i;
			break;
		}
	}
	if(checkedListProject>-1){
	FormConfiguration frm=new FormConfiguration(checkedProject[checkedListProject].Tag.ToString(), this);
	frm.Show(this);
	}
}
public void ResumeLoad(List<string>NW,List<string>RSM,List<string>RRR){
	LoadConfig();
	Work.Wrk.UpdateStatus(RRR);
	Work.Wrk.StartLoadProject(NW,EVENT_TYPE.NEW);
	Work.Wrk.StartLoadProject(RSM,EVENT_TYPE.RESUME);
}

void LoadAllToolStripMenuItemClick(object sender, EventArgs e){
	List<string> list=new List<string>();
	for(int i=0;i<panel1.Controls.Count;i++) list.Add(checkedProject[i].Tag.ToString());
	Work.Wrk.StartLoadProject(list,EVENT_TYPE.START);
}
void LoadSelectToolStripMenuItemClick(object sender, EventArgs e){
	List<string> list=new List<string>();
	for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Checked) list.Add(checkedProject[i].Tag.ToString());
	Work.Wrk.StartLoadProject(list,EVENT_TYPE.START);
}
void StopAllToolStripMenuItemClick(object sender, EventArgs e){
	Work.Wrk.StopAll();
}
void StopSelectToolStripMenuItemClick(object sender, EventArgs e){
	List<string> list=new List<string>();
	for(int i=0;i<panel1.Controls.Count;i++) if(checkedProject[i].Checked) list.Add(checkedProject[i].Tag.ToString());
	Work.Wrk.StopSelect(list);
}
void ImportToolStripMenuItemClick(object sender, EventArgs e)	{
	openFileDialog1.Filter="Project (*.pls)|*.pls";
	openFileDialog1.FilterIndex=1;
	openFileDialog1.RestoreDirectory=true;
	if(openFileDialog1.ShowDialog()==DialogResult.OK)
		ListSites.LoadConfig(openFileDialog1.FileName,this);
}
void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)	{

}
void XMLToolStripMenuItemClick(object sender, EventArgs e)	{
	List<string> ListNameThreading=new List<string>();
	for(int i=0;i<panel1.Controls.Count;i++) ListNameThreading.Add(checkedProject[i].Tag.ToString());
	if(ListNameThreading.Count>0)
		Work.Wrk.StopExport(ListNameThreading);

}
void MainFormFormClosed(object sender, FormClosedEventArgs e){
	Work.LoadAllTheard=false;
	foreach(KeyValuePair<string, ListSites.Project> p in ListSites.listSites){
		if(Work.StrtLd.ContainsKey(p.Key))
		if (Work.StrtLd[p.Key]!= null)
			Work.StrtLd[p.Key].Abort();
	}
	if (Work.WorkThreading!= null)  
   		if (Work.WorkThreading.IsAlive)
        	Work.ewh.Set();

	}

void ExportToolStripMenuItemClick(object sender, EventArgs e){

	}
void CSVToolStripMenuItemClick(object sender, EventArgs e){
	List<string> ListNameThreading=new List<string>();
	for(int i=0;i<panel1.Controls.Count;i++) 
		if(!Work.Wrk.StatusThread(checkedProject[i].Tag.ToString()))
			ListNameThreading.Add(checkedProject[i].Tag.ToString());
	if(ListNameThreading.Count>0){
		ExportForm1 frm=new ExportForm1(this,ListNameThreading);
		frm.Show(this);
	}
}
void SytemapToolStripMenuItemClick(object sender, EventArgs e)	{
	List<string> ListNameThreading=new List<string>();
	for(int i=0;i<panel1.Controls.Count;i++) 
		if((checkedProject[i].Checked)&&(!Work.Wrk.StatusThread(checkedProject[i].Tag.ToString()))) 
			ListNameThreading.Add(checkedProject[i].Tag.ToString());
	if(ListNameThreading.Count>0){
		ExportForm1 frm=new ExportForm1(this,ListNameThreading);
		frm.Show(this);
	}
}

void HtmlToolStripMenuItemClick(object sender, EventArgs e)	{
	List<string> ListNameThreading=new List<string>();
	for(int i=0;i<panel1.Controls.Count;i++) ListNameThreading.Add(checkedProject[i].Tag.ToString());
	if(ListNameThreading.Count>0)
		Work.Wrk.StopExport(ListNameThreading);
}

private Button[] ButtonDelete=new Button[CounView];
private Button[] ButtonArhive=new Button[CounView];
private Button[] ButtonView=new Button[CounView];
private Button ButtonNext=new Button();
private Button ButtonEnd=new Button();
private Button ButtonBack=new Button();
private Button ButtonStart=new Button();
private Button ButtonEnter=new Button();
private MaskedTextBox Str=new MaskedTextBox();
private Label lbl=new Label();
private RichTextBox[] ViewInfo= new RichTextBox[CounView];


void TabControl1SelectedIndexChanged(object sender, EventArgs e){
	LoadRecords(start,stop);
}
public void LoadRecords(int start,int stop){
	tabPage2.Controls.Clear();
	if(WothLoad==0)
	LoadRecordsInfoBloc(start,stop);
	if(WothLoad==1)
	LoadRecordsError(start,stop);
	resize();
}

public void LoadRecordsError(int start,int stop){
	int i;
	List<Records> Rcrds=new List<Records>();
	for(i=0;i<panel1.Controls.Count;i++) 
		if(checkedProject[i].Checked) {
		Rcrd.SetNameThreading(checkedProject[i].Tag.ToString());
		CountRow=Rcrd.CountRecordsError();
		break;
	}
	if(start<1){
		start=0;
		position=1;
	}
	if(stop<10)	stop=10;
	if(start>CountRow) {
		start=CountRow-10;
		position--;
	}
	if(stop>CountRow)	stop=CountRow;
	
	if(CountRow>0){
		Rcrds=Rcrd.GetListRecordsError(start,stop);
		for(i=0;i<Rcrds.Count;i++){
			CreateObjectForm(i);
			ViewInfo[i].Text=Rcrds[i].href+"\r\n"+Rcrds[i].txthref+"\r\n";
			ViewInfo[i].Tag=Rcrds[i].id.ToString();
			ButtonDelete[i].Tag=Rcrds[i].id;
			ButtonView[i].Tag=Rcrds[i].root_href;
		}
		lbl.Text=" from "+((int)Math.Ceiling((double)CountRow/10)).ToString();
		CreateObjectFormButton(i-1);	
	}else {
		lbl.Location= new System.Drawing.Point(40, 102+135*i);
		lbl.Size= new Size(250,250);
		lbl.Visible=true;
		lbl.Text="There are no records";
		tabPage2.Controls.Add(lbl);
		
	}
}


public void LoadRecordsInfoBloc(int start,int stop){
	int i;
	List<Records> Rcrds=new List<Records>();
	CountRow=0;
	for(i=0;i<panel1.Controls.Count;i++) 
		if(checkedProject[i].Checked) {
		Rcrd.SetNameThreading(checkedProject[i].Tag.ToString());
		CountRow=Rcrd.CountRecords();
		break;
	}
	
	if(start<1){
		start=0;
		position=1;
	}
	if(stop<0)	stop=0;
	if(start>CountRow) {
		start=CountRow-10;
		position--;
	}
	if(stop>CountRow){	
		stop=CountRow;
		start=CountRow-10;
	}
	
	if(CountRow>0){
		Rcrds=Rcrd.GetListRecordsInfoBlock(start,stop);
		for(i=0;i<Rcrds.Count;i++){
			CreateObjectForm(i);
			ViewInfo[i].Text=Rcrds[i].href+"\r\n"+Rcrds[i].txthref+"\r\n"+Rcrds[i].title+"\r\n"+Rcrds[i].xml;
			ViewInfo[i].Tag=Rcrds[i].id.ToString();
			ButtonDelete[i].Tag=Rcrds[i].id;
			ButtonView[i].Tag=Rcrds[i].href;
		}
		lbl.Text=" from "+(Math.Ceiling((double)CountRow/10)).ToString();
	CreateObjectFormButton(i-1);
	}else {
		lbl.Location= new System.Drawing.Point(40, 102+135*i);
		lbl.Size= new Size(250,250);
		lbl.Visible=true;
		lbl.Text="There are no records";
		tabPage2.Controls.Add(lbl);
		
	}
}

public void CreateObjectFormButton(int i){
	if(i>1){
	ButtonStart.Text="<<";
	ButtonStart.Location= new System.Drawing.Point(10, 102+135*i);
	ButtonStart.Visible=true;
	ButtonStart.Size= new Size(40,25);
	tabPage2.Controls.Add(ButtonStart);
	
	ButtonBack.Text="<";
	ButtonBack.Location= new System.Drawing.Point(60, 102+135*i);
	ButtonBack.Size= new Size(20,25);
	ButtonBack.Visible=true;
	tabPage2.Controls.Add(ButtonBack);
		
	Str.Text=position.ToString();
	Str.Location= new System.Drawing.Point(90, 102+135*i);
	Str.Size= new Size(40,25);
	Str.Visible=true;
	tabPage2.Controls.Add(Str);

	lbl.Location= new System.Drawing.Point(140, 102+135*i);
	lbl.Size= new Size(150,25);
	lbl.Visible=true;
	tabPage2.Controls.Add(lbl);

	ButtonEnter.Text="Go";
	ButtonEnter.Location= new System.Drawing.Point(300, 102+135*i);
	ButtonEnter.Size= new Size(73,25);
	ButtonEnter.Visible=true;
	tabPage2.Controls.Add(ButtonEnter);
		
	ButtonNext.Text=">";
	ButtonNext.Location= new System.Drawing.Point(380, 102+135*i);
	ButtonNext.Size= new Size(20,25);
	ButtonNext.Visible=true;
	tabPage2.Controls.Add(ButtonNext);
		
	ButtonEnd.Text=">>";
	ButtonEnd.Visible=true;
	ButtonEnd.Location= new System.Drawing.Point(410, 102+135*i);
	ButtonEnd.Size= new Size(40,25);
	
	tabPage2.Controls.Add(ButtonEnd);
}
	
}
public void CreateObjectForm(int i){
	ViewInfo[i]=new RichTextBox();
	ViewInfo[i].Location= new System.Drawing.Point(1,130*i);
	ViewInfo[i].Size= new Size(this.Size.Width-panel1.Size.Width-95,100);
	ViewInfo[i].ReadOnly=true;
	ViewInfo[i].Tag=i.ToString();
	ViewInfo[i].Visible=true;
	tabPage2.Controls.Add(ViewInfo[i]);
	
	ButtonDelete[i]=new Button();
	ButtonDelete[i].Text="Delete";
	ButtonDelete[i].Size= new Size(85,25);
	ButtonDelete[i].Location= new System.Drawing.Point(6, 102+130*i);
	ButtonDelete[i].Click+=ButtonDelet;
	ButtonDelete[i].Visible=true;
	tabPage2.Controls.Add(ButtonDelete[i]);
		
	ButtonArhive[i]=new Button();
	ButtonArhive[i].Text="Expand";
	ButtonArhive[i].Size= new Size(95,25);
	ButtonArhive[i].Location= new System.Drawing.Point(96, 102+130*i);
	ButtonArhive[i].Tag=i.ToString();
	ButtonArhive[i].Click+=ButtonArhiv;
	ButtonArhive[i].Visible=true;
	tabPage2.Controls.Add(ButtonArhive[i]);
		
	ButtonView[i]=new Button();
	ButtonView[i].Text="View";
	ButtonView[i].Size= new Size(85,25);
	ButtonView[i].Location= new System.Drawing.Point(195, 102+130*i);
	ButtonView[i].Click+=ButtonVie;
	ViewInfo[i].Visible=true;
	tabPage2.Controls.Add(ButtonView[i]);

}


public void ButtonVie(object sender, EventArgs e){
	Button button=(Button)sender;
	System.Diagnostics.Process.Start(button.Tag.ToString());
}
	
public void ButtonArhiv(object sender, EventArgs e){
	Button button=(Button)sender;
	if(button.Text=="Expand"){
	for(int i=0;i<CounView;i++)
		if((Convert.ToInt32(button.Tag)!=i)&&(ViewInfo[i]!=null)){
			ViewInfo[i].Visible=false;
			ButtonArhive[i].Visible=false;
			ButtonView[i].Visible=false;
			ButtonDelete[i].Visible=false;
	}

	ButtonStart.Visible=false;
	ButtonBack.Visible=false;
	Str.Visible=false;
	lbl.Visible=false;
	ButtonEnter.Visible=false;
	ButtonNext.Visible=false;
	ButtonEnd.Visible=false;
	NumberOpen=Convert.ToInt32(button.Tag);
	ViewInfo[NumberOpen].Location=new System.Drawing.Point(5,5);//new System.Drawing.Point(-100,130);
	ViewInfo[NumberOpen].Size=new Size(tabControl1.Size.Width-30,tabControl1.Size.Height-80);
	ViewInfo[NumberOpen].Visible=true;
	ButtonArhive[NumberOpen].Text="Roll it up";
	ButtonDelete[NumberOpen].Location=new System.Drawing.Point(6,tabControl1.Size.Height-50);
	ButtonArhive[NumberOpen].Location=new System.Drawing.Point(96,tabControl1.Size.Height-50);
	ButtonView[NumberOpen].Location=new System.Drawing.Point(195,tabControl1.Size.Height-50);
	} else { LoadRecords(start,stop);}
	
}
public void ButtonStrt(object sender, EventArgs e){
	Button button=(Button)sender;
	start=0;
	stop=10;
	position=1;
	LoadRecords(start,stop);
}
public void ButtonNxt(object sender, EventArgs e){
	Button button=(Button)sender;
	if(stop<CountRow){
	start=stop;
	stop=stop+10;
	}
	position++;
	int a=(int)Math.Ceiling((double)CountRow/10);
	if(position>a) position=a;
	LoadRecords(start,stop);
}

public void Buttonnd(object sender, EventArgs e){
	Button button=(Button)sender;
	start=CountRow-10;
	stop=CountRow;
	position=(int)Math.Ceiling((double)CountRow/10);
	LoadRecords(start,stop);
}
public void ButtonBac(object sender, EventArgs e){
	Button button=(Button)sender;
	if(stop>10){
	if(stop<start) start=stop-10;
	if(stop>10)	stop=stop-10;
	if(start>10) start=start-10;
	
	position--;
	if(position<1)position=1;
	}
	if(stop<=10) start = 0;
	LoadRecords(start,stop);
	
}
public void ButtonNter(object sender, EventArgs e){
	position=Convert.ToInt32(Str.Text);
	if((position>0)&&(position<(int)Math.Ceiling((double)CountRow/10))){
	start=position*10;
	stop=start+10;
	LoadRecords(start,stop);
	}
}

public void ButtonDelet(object sender, EventArgs e){
	Button button=(Button)sender;
	Rcrd.DeleteRecords(button.Tag.ToString());
	LoadRecords(start,stop);
}
void InfoBlockToolStripMenuItemClick(object sender, EventArgs e){
	tabPage2.Text="Information";
	WothLoad=0;
	LoadRecords(start,stop);
}
void ErrorToolStripMenuItemClick(object sender, EventArgs e){
	tabPage2.Text="Not uploaded";
	WothLoad=1;
	LoadRecords(start,stop);
}
void ClearHistoryToolStripMenuItemClick(object sender, EventArgs e){
	for(int i=0;i<panel1.Controls.Count;i++) 
		if(checkedProject[i].Checked) {
			if(File.Exists(appdata+"info\\"+checkedProject[i].Tag.ToString()+"\\log.txt")) File.Delete(appdata+"info\\"+checkedProject[i].Tag.ToString()+"\\log.txt");
			LogrichTextBox1.Text="";
	}
}
void ActivationToolStripMenuItemClick(object sender, EventArgs e){
	LicensKey frm=new LicensKey();
	frm.Show(this);
}
void OpisToolStripMenuItemClick(object sender, EventArgs e)	{
	LicenseText frm=new LicenseText("opisanie.mht");
	frm.Show(this);

		}
void LicensToolStripMenuItemClick(object sender, EventArgs e){
	LicenseText frm;
	if(File.Exists("Licens.bin"))
		frm=new LicenseText("LicensTest.mht");
	else
		frm=new LicenseText("tmplicens.mht");
	frm.Show(this);
	}
void TreyToolStripMenuItemClick(object sender, EventArgs e){

}
public void hiden(){
	this.ShowInTaskbar=false;
	notifyIcon1.Visible=true;
	Hide();
	this.WindowState=FormWindowState.Minimized;	
	
}
void NotifyIcon1DoubleClick(object sender, EventArgs e)	{
	if(this.WindowState==FormWindowState.Minimized)
		this.WindowState=FormWindowState.Normal;
	this.Activate();
	this.ShowInTaskbar=true;
	Show();
	notifyIcon1.Visible=false;
		}

      
}}

