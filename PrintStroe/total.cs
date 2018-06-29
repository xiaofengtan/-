using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrintStroe
{
    public partial class total : Form
    {
        DataTable CurrentData;

        DataTable AllPaper = Model.Paper_Store.GetAllPaperTable();

        DataTable _totalData;
        DataTable TotalData
        {
            set
            {
                _totalData = value;
                if (value != null)
                {
                    button5.Visible = true;
                }
                else
                    button5.Visible = false;
            }
            get
            {
                return _totalData;
            }
        }
        public total()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 90;
            button5.Visible = false;
            button6.Visible = false;
            groupBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime LastTime = dateTimePicker1.Value;
            DataTable dt = Model.Store_month.GetMonthStore(LastTime);
            if (dt == null || dt.Rows.Count < 1)
            {
                dt = Model.Store_month.MakeNewStore(LastTime.Year, LastTime.Month);
                TotalData = dt;
            }
            else
            {
                List<Model.Store_month> Allstroe = DataSource.ORMHelper.TbToModelList<Model.Store_month>(dt);
                Model.Store_month total = new Model.Store_month();
                foreach (Model.Store_month sm in Allstroe)
                {
                    total.LastMoney += sm.LastMoney;
                    total.LastNum += sm.LastNum;
                    total.InMoney += sm.InMoney;
                    total.InNum += sm.InNum;
                    total.OutMoney += sm.OutMoney;
                    total.OutNum += sm.OutNum;
                    total.CurrentMoney += sm.CurrentMoney;
                    total.CurrentNum += sm.CurrentNum;
                }
                Allstroe.Add(total);
                dt = DataSource.ORMHelper.ModelListToTb<Model.Store_month>(Allstroe);
                TotalData = dt;
            }

            dataGridView1.DataSource = dt;
            List<string> title = Model.Store_month.GetColumNikeName();
            for (int i = 0; i < title.Count; i++)
                dataGridView1.Columns[i].HeaderText = title[i];
            CurrentData = dt;
            bool Nobanlance = false;
            //隐藏数量为0的行
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int lastnum = int.Parse(dt.Rows[i]["LastNum"].ToString());
                int innum = int.Parse(dt.Rows[i]["InNum"].ToString());
                int outnum = int.Parse(dt.Rows[i]["OutNum"].ToString());
                int currentnum = int.Parse(dt.Rows[i]["CurrentNum"].ToString());
                if (lastnum + innum - outnum != currentnum)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                if (lastnum == 0 && innum == 0 && outnum == 0 && currentnum == 0)
                {
                    cm.SuspendBinding();
                    dataGridView1.Rows[i].Visible = false;
                    cm.ResumeBinding();
                    Nobanlance = true;
                }
            }
            CurrentData.TableName = "库存汇总表";
            this.Cursor = Cursors.Default;
            if (Nobanlance)
            {
                button6.Visible = true;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            DataTable dt = Model.Paper_Out.GetYearMonth(dateTimePicker1.Value);
            decimal money = 0;
            int num = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal m = 0;
                decimal.TryParse(dt.Rows[i]["Money"].ToString(), out m);
                int n = 0;
                int.TryParse(dt.Rows[i]["Num"].ToString(), out n);
                money += m;
                num += n;
            }
            DataRow dr = dt.NewRow();
            dr["PaperName"] = "合计";
            dr["Money"] = money;
            dr["Num"] = num;
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            CurrentData = dt;
            List<string> title = Model.Paper_Out.GetColumNikeName();
            for (int i = 0; i < title.Count; i++)
                dataGridView1.Columns[i].HeaderText = title[i];
            CurrentData.TableName = "出库汇总表";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            List<Model.Paper_In> Allin = Model.Paper_In.GetYearMonthList(dateTimePicker1.Value);

            Model.Paper_In total = new Model.Paper_In();
            total.PaperName = "汇总";
            foreach (Model.Paper_In pi in Allin)
            {
                total.Num += pi.Num;
                total.Money += pi.Money;
            }
            Allin.Add(total);
            CurrentData = DataSource.ORMHelper.ModelListToTb<Model.Paper_In>(Allin);
            dataGridView1.DataSource = CurrentData;
            List<string> title = Model.Paper_In.GetColumNikeName();
            for (int i = 0; i < title.Count; i++)
                dataGridView1.Columns[i].HeaderText = title[i];
            CurrentData.TableName = "入存汇总表";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CurrentData != null)
            {
                var newBook = Common.BuildWorkbook(dataGridView1, CurrentData.TableName);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "d:\\";
                saveFileDialog1.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = dateTimePicker1.Value.ToLongDateString() + CurrentData.TableName;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
                {
                    var fs = File.OpenWrite(saveFileDialog1.FileName);
                    newBook.Write(fs);
                    MessageBox.Show("存储文件成功！", "保存文件");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int TotalIndex = TotalData.Rows.Count - 1;
            if (TotalIndex > 0)
            {
                bool Allow = true;
                Model.Store_month First = DataSource.ORMHelper.RowToModel<Model.Store_month>(TotalData.Rows[0]);
                int count = Model.Store_month.GetMonthStore(First.Year, First.Month).Rows.Count;
                if (count > 1)
                {
                    DialogResult dr = MessageBox.Show("本月已经结存，不能重复结存！点击退出", "提示");
                    return;
                }
                Model.Store_month Total = DataSource.ORMHelper.RowToModel<Model.Store_month>(TotalData.Rows[TotalIndex]);
                if (Total != null)
                {
                    if (Total.LastNum == 0)
                    {
                        DialogResult dr = MessageBox.Show("上月没有结存，请重新检查库存汇总数据！是否继续！", "提示", MessageBoxButtons.YesNo);
                        if (dr != DialogResult.Yes)
                        {
                            Allow = false;
                        }
                    }
                    if (Total.InNum == 0)
                    {
                        DialogResult dr = MessageBox.Show("本月入库数据为0，请确认入库数据的正确性！是否继续！", "提示", MessageBoxButtons.YesNo);
                        if (dr != DialogResult.Yes)
                        {
                            Allow = false;
                        }
                    }
                    if (Total.OutNum == 0)
                    {
                        DialogResult dr = MessageBox.Show("本月出库数据为0，请确认出库数据的正确性！是否继续！", "提示", MessageBoxButtons.YesNo);
                        if (dr != DialogResult.Yes)
                        {
                            Allow = false;
                        }
                    }
                    int balance = 0;
                    balance = Total.LastNum + Total.InNum - Total.OutNum;
                    if (balance != Total.CurrentNum)
                    {
                        DialogResult dr = MessageBox.Show("本月库存数据不平衡，请检查详细的出库出库数据的正确性！下表中红色部分数据为不平衡数据，请确认！是否继续！", "提示", MessageBoxButtons.YesNo);
                        if (dr != DialogResult.Yes)
                        {
                            Allow = false;
                        }
                    }
                    if (Allow)
                    {
                        DialogResult dr = MessageBox.Show("本月库存数据即将开始结存。结存后的数据不能修改。修改也不会影响库存表！", "提示", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            TotalData.Rows.RemoveAt(TotalIndex);
                            TotalIndex = Model.Store_month.InsertData(TotalData);
                            if (TotalIndex == TotalData.Rows.Count)
                            {
                                MessageBox.Show("本月库存数据结存成功！", "提示");
                            }
                            else
                            {
                                MessageBox.Show("本月库存数据结存失败！", "提示");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("数据错误不能结存，请重新检查库存汇总数据！");
                return;

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable Alldata = (DataTable)dataGridView1.DataSource;
            if (Alldata != null)
            {
                if (Alldata.Rows.Count > 1)
                {
                    List<Model.Paper_Store> NeedUpdatePaper = new List<Model.Paper_Store>();
                    List<Model.Store_month> AllStore = DataSource.ORMHelper.TbToModelList<Model.Store_month>(Alldata);
                    foreach (Model.Store_month sm in AllStore)
                    {
                        if (sm.PaperId > 0 && sm.LastNum - sm.OutNum + sm.InNum != sm.CurrentNum)
                        {
                            Model.Paper_Store ps = Model.Paper_Store.GetPaperById(sm.PaperId);
                            if (ps != null)
                            {
                                ps.Num = sm.LastNum - sm.OutNum + sm.InNum;
                                ps.TaxiMoney = sm.LastMoney - sm.OutMoney + sm.InMoney;
                                if (ps.Num != 0)
                                {
                                    ps.TaxiPrice = Math.Abs(Math.Round(ps.TaxiMoney / ps.Num, 2));
                                }
                                NeedUpdatePaper.Add(ps);
                            }
                        }
                    }
                    if (NeedUpdatePaper.Count > 0)
                    {
                        DialogResult dr = MessageBox.Show("本月当前库存数据即将强行平衡！是否继续？", "提示", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            foreach (Model.Paper_Store ps in NeedUpdatePaper)
                            {
                                Model.Paper_Store.Update(ps);
                            }

                        }
                    }
                    button6.Visible = false;
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            groupBox1.Visible = checkBox1.Checked;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int type = 0;
            //if (!(comboBox1.Items.Count > 0 && comboBox1.SelectedIndex >= 0))
            //{
            //    MessageBox.Show("通过拼音简写选择要出库的纸张！", "提示");
            //    return;
            //}
            if (comboBox1.SelectedValue != null)
            {
                type = int.Parse(comboBox1.SelectedValue.ToString());
            }
            else
                type = 0;

            DateTime LastTime = dateTimePicker1.Value.AddMonths(-1);
            //查上个月该品种库存的结存情况；

            List<Model.Store_month> AllStroe = Model.Store_month.GetMonthStoreList(LastTime);
            List<Model.Paper_Store> AllPaper = Model.Paper_Store.GetAllPaperList();

            Model.Store_month LastStroe = null;
            Model.Paper_Store paper = null;

            bool LastOk = AllStroe != null && AllStroe.Count > 0;
            if (!LastOk)
            {
                DialogResult dr = MessageBox.Show("上月库存还没有结存！是否继续？如继续只汇总出入库情况！", "提示", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    LastStroe = new Model.Store_month();
                }
            }
            else
            {
                if (type > 0)
                {
                    paper = Model.Paper_Store.GetPaperById(type);
                    for (int i = 0; i < AllStroe.Count; i++)
                    {
                        if (AllStroe[i].PaperId == type)
                        {
                            LastStroe = AllStroe[i];
                            break;
                        }
                    }
                }
            }

            //Model.Store_month LastStroe = Model.Store_month.GetPaperMonthStore(LastTime.Year, LastTime.Month, type);
            //如果没有上月结存。就创建个空的记录；

            LastTime = LastTime.AddMonths(1);
            List<Model.Paper_In> Allin = Model.Paper_In.GetYearMonthList(LastTime);
            List<Model.Paper_Out> AllOut = Model.Paper_Out.GetYearMonthList(LastTime);
            List<Model.Store_month> Result = new List<Model.Store_month>();
            if (type > 0)
            {
                if (LastStroe == null)
                {
                    LastStroe = new Model.Store_month();
                }
                Result.AddRange(GetSinglePaperList(paper, LastStroe, Allin, AllOut));
            }
            else
            {
                int AllInNum = 0, AllOutNum = 0,AllLastNum=0;
                decimal ALLInMoney = 0, AllOutMoney = 0, AllLastMoney = 0 ;
                Model.Store_month total = new Model.Store_month();
                total.PaperName = "总计";
                for (int i = 0; i < AllPaper.Count; i++)
                {

                    paper = AllPaper[i];
                    LastStroe = null;
                    for (int j = 0; j < AllStroe.Count; j++)
                    {
                        if (AllStroe[j].PaperId == paper.PaperId)
                        {
                            LastStroe = AllStroe[j];
                            break;
                        }
                    }
                    if (LastStroe == null)
                    {
                        LastStroe = new Model.Store_month();
                    }
                    if (paper != null && LastStroe != null)
                    {
                        List<Model.Store_month> temp = GetSinglePaperList(paper, LastStroe, Allin, AllOut);
                        if (temp != null)
                        {
                            Result.AddRange(temp);
                            Model.Store_month t1 = temp[temp.Count - 1];
                            if (t1!=null)
                            {
                                AllInNum += t1.InNum;
                                AllOutNum += t1.OutNum;
                                AllOutMoney += t1.OutMoney;
                                ALLInMoney += t1.InMoney;
                                AllLastNum += t1.LastNum;
                                AllLastMoney += t1.LastMoney;
                                if (t1.LastNum + t1.InNum - t1.OutNum == t1.CurrentNum)
                                    t1.OrderNo = 0;
                                else
                                    t1.OrderNo = -1;
                            }
                        }
                    }
                }
                total.InMoney = ALLInMoney;
                total.InNum = AllInNum;
                total.OutNum = AllOutNum;
                total.OutMoney = AllOutMoney;
                total.LastNum = AllLastNum;
                total.LastMoney = AllLastMoney;
                total.CurrentNum = AllInNum + AllLastNum - AllOutNum;
                total.CurrentMoney = ALLInMoney + AllLastMoney - AllOutMoney;
                Result.Add(total);
            }
            DataTable dt = DataSource.ORMHelper.ModelListToTb<Model.Store_month>(Result);
            dataGridView1.DataSource = dt;
            List<string> title = Model.Store_month.GetColumNikeName();
            int cindex = title.Count;
            for (int i = 0; i < cindex; i++)
                dataGridView1.Columns[i].HeaderText = title[i];
            for (int j = 0; j < dt.Rows.Count;j++)
            {
                if(dt.Rows[j][cindex-1].ToString()=="-1")
                    dataGridView1.Rows[j].DefaultCellStyle.ForeColor = Color.Red;
            }
            CurrentData = dt;
            CurrentData.TableName = LastTime.Year.ToString() + "年" + LastTime.Month.ToString() + "月汇总表";
        }
        private List<Model.Store_month> GetSinglePaperList(Model.Paper_Store paper, Model.Store_month LastStroe, List<Model.Paper_In> Allin, List<Model.Paper_Out> AllOut)
        {
            List<Model.Store_month> Result = new List<Model.Store_month>();
            bool HaveData = false;
            //LastStroe.PaperName += "上月结余";

            //Result.Add(LastStroe);
            if (LastStroe.LastNum != 0 || LastStroe.CurrentNum != 0)
                HaveData = true;
            int AllInNum = 0, AllOutNum = 0;
            decimal ALLInMoney = 0, AllOutMoney = 0;
            foreach (Model.Paper_In pi in Allin)
            {
                if (paper.PaperId == pi.PaperId)
                {
                    Model.Store_month NewStroe = new Model.Store_month();
                    NewStroe.LastNum = LastStroe.LastNum;
                    NewStroe.LastMoney = LastStroe.LastMoney;

                    NewStroe.InNum = pi.Num;
                    NewStroe.PaperId = paper.PaperId;
                    NewStroe.PaperName = paper.PaperName;
                    NewStroe.CalTime = pi.InTime;
                    NewStroe.InMoney = pi.Money;
                    Result.Add(NewStroe);
                    AllInNum += pi.Num;
                    ALLInMoney += pi.Money;
                    HaveData = true;
                }
            }
            foreach (Model.Paper_Out po in AllOut)
            {
                if (paper.PaperId == po.PaperId)
                {
                    Model.Store_month NewStroe = new Model.Store_month();
                    NewStroe.LastNum = LastStroe.LastNum;
                    NewStroe.LastMoney = LastStroe.LastMoney;
                    NewStroe.Price = LastStroe.Price;
                    NewStroe.OutNum = po.Num;
                    NewStroe.PaperId = paper.PaperId;
                    NewStroe.PaperName = paper.PaperName;
                    NewStroe.CalTime = po.OutTime;
                    NewStroe.OutMoney = po.Money;
                    int no = 0;
                    if (int.TryParse(po.b1, out no))
                    {
                        NewStroe.OrderNo = no;
                    }
                    else
                    {
                        NewStroe.OrderNo = 0;
                    }
                    Result.Add(NewStroe);
                    AllOutNum += po.Num;
                    AllOutMoney += po.Money;
                    HaveData = true;
                }
            }
            Model.Store_month total = new Model.Store_month();
            if (Result.Count == 0)
            {
                if (HaveData)
                {
                    Result.Add(LastStroe);
                }
            }
            total.PaperName = "小计";
            total.PaperId = LastStroe.PaperId;
            total.LastNum = LastStroe.LastNum;
            total.LastMoney = LastStroe.LastMoney;
            total.InMoney = ALLInMoney;
            total.InNum = AllInNum;
            total.OutNum = AllOutNum;
            total.OutMoney = AllOutMoney;
            total.CurrentNum = LastStroe.LastNum + AllInNum - AllOutNum;
            total.CurrentMoney = LastStroe.LastMoney + ALLInMoney - AllOutMoney;
            if (total.LastNum != 0)
            {
                total.CurrentPrice = Math.Round(total.LastMoney / total.LastNum, 2);
            }
            Result.Add(total);
            if (HaveData)
                return Result;
            else
                return null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            if (code.Length > 0 && AllPaper != null)
            {
                DataRow[] drs = AllPaper.Select("PaperCode like '%" + code + "%'");
                if (drs.Length > 0)
                {
                    comboBox1.DataSource = null;
                    List<Model.NameType> paperlist = new List<Model.NameType>();
                    for (int i = 0; i < drs.Length; i++)
                    {
                        Model.NameType nt = new Model.NameType() { Id = int.Parse(drs[i]["PaperId"].ToString()), Name = drs[i]["PaperName"].ToString() };
                        paperlist.Add(nt);
                    }
                    Common.BindCombox(comboBox1, paperlist);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateTime LastTime = dateTimePicker1.Value;
            List<Model.Paper_Out> AllOut = Model.Paper_Out.GetYearMonthList(LastTime);

            if (AllOut != null && AllOut.Count > 0)
            {
                int AllNum = 0;
                decimal AllMoney = 0;

                List<Model.Paper_Out> Reslut = new List<Model.Paper_Out>();
                for (int i = 0; i < AllOut.Count; i++)
                {
                    if (AllOut[i].Remark.IndexOf("业务部") >= 0 || AllOut[i].Remark.IndexOf("手动单笔") >= 0 || AllOut[i].PaperId == 0)
                    {
                        continue;
                    }
                    int PaperId = AllOut[i].PaperId;
                    Reslut.Add(AllOut[i]);
                    AllNum += AllOut[i].Num;
                    AllMoney += AllOut[i].Money;
                    AllOut[i].PaperId = 0;
                    for (int j = i; j < AllOut.Count - i; j++)
                    {
                        if (PaperId == AllOut[j].PaperId)
                        {
                            if (AllOut[j].Remark.IndexOf("业务部") >= 0 || AllOut[j].Remark.IndexOf("手动单笔") >= 0 )
                            {
                                continue;
                            }
                            Reslut.Add(AllOut[j]);
                            AllOut[j].PaperId = 0;
                            AllNum += AllOut[j].Num;
                            AllMoney += AllOut[j].Money;
                        }
                    }
                }
                if (Reslut.Count > 0)
                {
                    Model.Paper_Out TotalOut = new Model.Paper_Out();
                    TotalOut.PaperName = "合计";
                    TotalOut.Num = AllNum;
                    TotalOut.Money = AllMoney;
                    Reslut.Add(TotalOut);
                    CurrentData = DataSource.ORMHelper.ModelListToTb<Model.Paper_Out>(Reslut);
                    dataGridView1.DataSource = CurrentData;
                    List<string> title = Model.Paper_Out.GetColumNikeName();
                    for (int i = 0; i < title.Count; i++)
                        dataGridView1.Columns[i].HeaderText = title[i];
                    CurrentData.TableName = "商彩自接业务出库汇总表";
                }
            }
            else
            {
                MessageBox.Show(LastTime.ToShortDateString() + "还没有出库记录！");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DateTime LastTime = dateTimePicker1.Value;
            List<Model.Paper_Out> AllOut = Model.Paper_Out.GetYearMonthList(LastTime);

            if (AllOut != null && AllOut.Count > 0)
            {
                int AllNum = 0;
                decimal AllMoney = 0;

                List<Model.Paper_Out> Reslut = new List<Model.Paper_Out>();
                for (int i = 0; i < AllOut.Count; i++)
                {
                    if (AllOut[i].Remark.IndexOf("业务部") + AllOut[i].Remark.IndexOf("手动单笔") < -1 || AllOut[i].PaperId == 0)
                    {
                        continue;
                    }
                    int PaperId = AllOut[i].PaperId;
                    Reslut.Add(AllOut[i]);
                    AllNum += AllOut[i].Num;
                    AllMoney += AllOut[i].Money;
                    AllOut[i].PaperId = 0;
                    for (int j = i; j < AllOut.Count - i; j++)
                    {
                        if (PaperId == AllOut[j].PaperId)
                        {
                            if (AllOut[j].Remark.IndexOf("业务部") + AllOut[j].Remark.IndexOf("手动单笔") < -1 )
                            {
                                continue;
                            }
                            Reslut.Add(AllOut[j]);
                            AllOut[j].PaperId = 0;
                            AllNum += AllOut[j].Num;
                            AllMoney += AllOut[j].Money;
                        }
                    }
                }
                if (Reslut.Count > 0)
                {
                    Model.Paper_Out TotalOut = new Model.Paper_Out();
                    TotalOut.PaperName = "合计";
                    TotalOut.Num = AllNum;
                    TotalOut.Money = AllMoney;
                    Reslut.Add(TotalOut);
                    CurrentData = DataSource.ORMHelper.ModelListToTb<Model.Paper_Out>(Reslut);
                    dataGridView1.DataSource = CurrentData;
                    List<string> title = Model.Paper_Out.GetColumNikeName();
                    for (int i = 0; i < title.Count; i++)
                        dataGridView1.Columns[i].HeaderText = title[i];
                    CurrentData.TableName = "业务部出库汇总表";

                }
            }
            else
            {
                MessageBox.Show(LastTime.ToShortDateString() + "还没有出库记录！");
            }
        }
    }
}
