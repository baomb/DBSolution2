using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms.Design;
namespace SdlDB.Utility
{
    public class PageNavigator : ToolStrip
    {
        const string FirstTipText = "显示第一页";
        const string PreviousTipText = "显示上一页";
        const string NextTipText = "显示下一页";
        const string LastTipText = "显示最后一页";
        const string ToolTipText = "第 n 页";
        const string LabelTipText = "总页数";
        const string QueryTipText = "跳转到第 n 页(n->输入的数字)";
        private ToolStripItem currentItem;
        private ToolStripItem firtItem;
        private ToolStripItem nextItem;
        private ToolStripItem previousItem;
        private ToolStripItem lastItem;
        private ToolStripItem textItem;
        private ToolStripItem labelItem;
        private ToolStripItem labelItemPrefix;
        private ToolStripItem labelItemEnd;
        private ToolStripItem queryItem;

        private ToolStripSeparator toolSep1;
        private ToolStripSeparator toolSep2;
        private ToolStripSeparator toolSep3;
        private ToolStripSeparator toolSep4;
        private ToolStripSeparator toolSep5;

        private int pageIndex = 1;
        //static object pageIndexChangingKey = new object();
        private static readonly object EventPageChange = new object();
        /// <summary>        
        /// 当前选项        
        /// </summary>        
        public ToolStripItem CurrentItem
        {
            get { return this.currentItem; }
        }
        /// <summary>       
        /// 支持分页        
        /// </summary>        
        private bool SupportPaging
        { get; set; }
        /// <summary>        
        /// 数据源       
        /// /// </summary>        
        private DataTable DataSource
        { get; set; }
        /// <summary>        
        /// 数据源记录总行数        
        /// </summary>        
        public int DataSourceCount
        { get; set; }
        /// <summary>        
        /// 当前页索引        
        /// </summary>        
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
            set
            {
                pageIndex = value;
            }
        }
        /// <summary>        
        /// 分页页记录行数        
        /// </summary>        
        [DefaultValue(10)]
        public int PageSize
        {
            get;
            set;
        }
        /// <summary>        
        /// 总页数        
        /// </summary>        
        public int PageCount
        {
            get
            {
                try
                {
                    int iCount = DataSourceCount / PageSize;
                    if (DataSourceCount % PageSize > 0)
                    {
                        iCount = iCount + 1;
                    }
                    return iCount;
                }
                catch
                {
                    return 0;
                }
            }
        }

        bool ValidateInput(string inputString)
        {
            Regex reg = new Regex("^[1-9]\\d*$");
            Match match = reg.Match(inputString);
            return match.Success;
        }
        public PageNavigator()
        {
            InitializingComponent();
            this.KeyUp += delegate(object sender, KeyEventArgs e)
            {

            };
        }
        public void InitializingComponent()
        {
            firtItem = new ToolStripButton();
            firtItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //firtItem.Image = CreateBitmap(FirstImage);
            firtItem.Name = "PageNavigatorMoveFirstItem";
            firtItem.ToolTipText = FirstTipText;
            firtItem.Text = FirstTipText.Replace("显示", "");

            toolSep1 = new ToolStripSeparator();
            toolSep1.Name = "toolSep1";
            toolSep1.Size = new System.Drawing.Size(6, 25);

            firtItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //firtItem.Image = CreateBitmap(FirstImage);
            firtItem.Name = "PageNavigatorMoveFirstItem";
            firtItem.ToolTipText = FirstTipText;
            firtItem.Text = FirstTipText.Replace("显示", "");

            toolSep2 = new ToolStripSeparator();
            toolSep2.Name = "toolSep2";
            toolSep2.Size = new System.Drawing.Size(6, 25);

            previousItem = new ToolStripButton();
            previousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //previousItem.Image = CreateBitmap(PreviousImage);
            previousItem.Name = "PageNavigatorMovePreviousItem";
            previousItem.ToolTipText = PreviousTipText;
            previousItem.Text = PreviousTipText.Replace("显示", ""); ;

            toolSep3 = new ToolStripSeparator();
            toolSep3.Name = "toolSep3";
            toolSep3.Size = new System.Drawing.Size(6, 25);

            nextItem = new ToolStripButton();
            nextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //nextItem.Image = CreateBitmap(NextImage);
            nextItem.Name = "PageNavigatorMoveNextItem";
            nextItem.ToolTipText = NextTipText;
            nextItem.Text = NextTipText.Replace("显示", ""); ;

            toolSep4 = new ToolStripSeparator();
            toolSep4.Name = "toolSep4";
            toolSep4.Size = new System.Drawing.Size(6, 25);

            lastItem = new ToolStripButton();
            lastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //lastItem.Image = CreateBitmap(LastImage);
            lastItem.Name = "PageNavigatorMoveLastItem";
            lastItem.ToolTipText = LastTipText;
            lastItem.Text = LastTipText.Replace("显示", ""); ;

            textItem = new ToolStripTextBox();
            textItem.Name = "PageNavigatorTextItem";
            textItem.ToolTipText = ToolTipText;
            textItem.Size = new Size(45, 20);

            labelItemPrefix = new ToolStripLabel();
            labelItemPrefix.Text = "/";
            labelItemPrefix.Name = "PageNavigatorLabelPrefix";

            labelItem = new ToolStripLabel();
            labelItem.Text = this.pageIndex.ToString();
            labelItem.Name = "PageNavigatorLabelItem";
            labelItem.ToolTipText = LabelTipText;

            labelItemEnd = new ToolStripLabel();
            labelItemEnd.Text = " 页 ";
            labelItemEnd.Name = "PageNavigatorLabelEnd";

            queryItem = new ToolStripButton();
            queryItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //queryItem.Image = CreateBitmap(QueryImage);
            queryItem.Name = "PageNavigatorQueryItem";
            queryItem.ToolTipText = QueryTipText;
            queryItem.Text = "跳转";

            toolSep5 = new ToolStripSeparator();
            toolSep5.Name = "toolSep5";
            toolSep5.Size = new System.Drawing.Size(6, 25);

            this.Items.AddRange(new ToolStripItem[] 
            { firtItem, toolSep1,previousItem,toolSep2, nextItem,toolSep3, lastItem,textItem, labelItemPrefix, labelItem, labelItemEnd, toolSep4,queryItem,toolSep5
            });
        }

        public event EventHandler PageChanged
        {
            add
            {
                Events.AddHandler(EventPageChange, value);
            }
            remove
            {
                Events.RemoveHandler(EventPageChange, value);
            }

        }
        protected void OnPageChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventPageChange];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //public event EventHandler PageIndexChanging
        //{
        //    add
        //    {
        //        Events.AddHandler(pageIndexChangingKey, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(pageIndexChangingKey, value);
        //    }
        //}

        //protected virtual void OnPageIndexChanging(EventArgs e)
        //{
        //    EventHandler handler = (EventHandler)Events[pageIndexChangingKey];
        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}

        bool EnsureToolStripItemState(int index)
        {
            if (index == 1) //如果是第一页，则第一页灰显，作用是避免不必要的点击造成没必要的数据传输
            {
                this.firtItem.Enabled = false;
            }
            else
            {
                this.firtItem.Enabled = true;
            }

            if (index > 1) //如果当前页大于1，则上一页显示，否则灰显
            {
                previousItem.Enabled = true;
            }
            else
            {
                previousItem.Enabled = false;
            }

            if (index < PageCount)//如果当前页小于总页数，则下一页显示，否则灰显
            {
                nextItem.Enabled = true;
            }
            else
            {
                nextItem.Enabled = false;
            }

            if (index == PageCount || PageCount == 0)//如果当前页为最后一页，则末页灰显
            {
                lastItem.Enabled = false;
            }
            else
            {
                lastItem.Enabled = true;
            }

            //if (PageCount == 1)
            //{
            //    this.firtItem.Enabled = false;
            //    this.previousItem.Enabled = false;
            //    this.nextItem.Enabled = false;
            //    this.lastItem.Enabled = false;
            //}
            //else
            //{
            //    if (index == 1)
            //    {
            //        this.firtItem.Enabled = false;
            //        this.previousItem.Enabled = false;
            //        this.nextItem.Enabled = true;
            //        this.lastItem.Enabled = true;
            //    }
            //    else if (index == PageCount)
            //    {
            //        this.firtItem.Enabled = true;
            //        this.previousItem.Enabled = true;
            //        this.nextItem.Enabled = false;
            //        this.lastItem.Enabled = false;
            //    }
            //}
            return true;
        }

        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            base.OnItemClicked(e);
            this.currentItem = e.ClickedItem;
            switch (e.ClickedItem.Name)
            {
                case "PageNavigatorMoveFirstItem":
                    pageIndex = 1;
                    this.textItem.Text = pageIndex.ToString();
                    this.labelItem.Text = this.PageCount.ToString();
                    OnPageChanged(EventArgs.Empty);
                    break;
                case "PageNavigatorMovePreviousItem":
                    if (PageIndex > 1)
                    {
                        pageIndex--;
                        this.textItem.Text = pageIndex.ToString();
                        this.labelItem.Text = this.PageCount.ToString();
                        OnPageChanged(EventArgs.Empty);
                    }
                    break;
                case "PageNavigatorMoveNextItem":
                    if (pageIndex < PageCount)
                    {
                        pageIndex++;
                        this.textItem.Text = pageIndex.ToString();
                        this.labelItem.Text = this.PageCount.ToString();
                    }
                    OnPageChanged(EventArgs.Empty);
                    break;
                case "PageNavigatorMoveLastItem":
                    pageIndex = PageCount;
                    this.textItem.Text = pageIndex.ToString();
                    this.labelItem.Text = this.PageCount.ToString();
                    OnPageChanged(EventArgs.Empty);
                    break;
                case "PageNavigatorQueryItem":
                    ToolStripTextBox txt = this.Items["PageNavigatorTextItem"] as ToolStripTextBox;
                    if (txt != null)
                    {
                        if (!ValidateInput(txt.Text.Trim()))
                        {
                            MessageBox.Show("只能输入大于零的数字");
                            return;
                        }
                        int index = 1;
                        int.TryParse(txt.Text, out index);

                        if (1 <= index && index <= PageCount)
                        {
                            pageIndex = index;
                            this.textItem.Text = pageIndex.ToString();
                            this.labelItem.Text = this.PageCount.ToString();
                            OnPageChanged(EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("数字超出范围");
                        }
                    }
                    break;
                default:
                    break;
            }
            EnsureToolStripItemState(pageIndex);

            //OnPageChanged(EventArgs.Empty);
        }
        public void BindData()
        {
            this.textItem.Text = pageIndex.ToString();
            this.labelItem.Text = this.PageCount.ToString();
            EnsureToolStripItemState(pageIndex);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DataSource = null;
            }
            base.Dispose(disposing);
        }
    }
}
