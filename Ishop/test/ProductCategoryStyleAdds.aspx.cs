using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_ProductCategoryStyleAdds :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.HorizontalAlign = HorizontalAlign.Left;
        for(int i=0;i<6;i++)
        {

            Literal Ltrlbr = new Literal();
            Ltrlbr.Text = "<br>";
            Label A = new Label(); 
            A.Text = "属性选择" + i.ToString() ;
        if (i == 3) //多选的情况
        {
            string CheckListID = "Chk" + i.ToString();
            CheckBoxList Chk1 = new CheckBoxList();
            Chk1.ID = CheckListID;
            Chk1.ClientIDMode = ClientIDMode.Static;
            Chk1.DataSource = this.FillDataSet("select * from ProdCate", "ProdCate");
            Chk1.DataTextField = "ProdcateName";
            Chk1.DataValueField = "ProdcateID";
            Chk1.DataBind();
            //样式 
            Chk1.Style.Add("margin-top", "10px");
            Chk1.Style.Add("width", "90%");
            Chk1.Style.Add("font-Size", "12px");
            Chk1.Style.Add("font-weight", "normal");
            Chk1.RepeatColumns = 3;
            Chk1.RepeatDirection = RepeatDirection.Horizontal;
            Chk1.RepeatLayout = RepeatLayout.Table; 
            Panel1.Controls.Add(A);
            Panel1.Controls.Add(Chk1);
            Panel1.Controls.Add(Ltrlbr);

        }
        else
        {
            string DropDownID = "DDL" + i.ToString();

            DropDownList DL1 = new DropDownList();

            DL1.ID = DropDownID;

            DL1.DataSource = this.FillDataSet("select * from ProdCate", "ProdCate");
            DL1.DataTextField = "ProdcateName";
            DL1.DataValueField = "ProdcateID";
            DL1.DataBind();
            DL1.Style.Add("padding", "10px");
            DL1.Width = Unit.Pixel(200);
            DL1.Height = Unit.Pixel(25);
            DL1.Style.Add("margin-top", "10px");
            Panel1.CssClass = "cls";
            Panel1.Controls.Add(A);
            Panel1.Controls.Add(DL1);
            if (i % 2 == 0) { Panel1.Controls.Add(Ltrlbr); }
        }
       }
       
        //=======================================================

        //Style S = new Style();
        //S.BorderColor = System.Drawing.Color.LightGray;
        //S.BorderWidth = Unit.Pixel(1); 
        //Panel1.MergeStyle(S);
        //Label AA = new Label();
        //AA.Text = "性别选择";

        //string bb="DDL2";
        //DropDownList DL2 = new DropDownList();
        //DL2.CssClass = "cls";

        //DL2.ID = bb;
        //DL2.DataSource = this.FillDataSet("select * from ProdSeries", "ProdSeries");
        //DL2.DataTextField = "ProdSeriesName";
        //DL2.DataValueField = "ProdSeriesID";
        //DL2.DataBind();


        //Panel1.Controls.Add(AA);
        //Panel1.Controls.Add(DL2);

        ////==================================================
        //DropDownList DL3 = new DropDownList();
        //DL3.DataSource = this.FillDataSet("select * from ProdType", "ProdType");
        //DL3.DataTextField = "ProdTypeName";
        //DL3.DataValueField = "ProdTypeID";
        //DL3.DataBind();
        //Label AAA = new Label();
        //AAA.Text = "店铺分类";

        //Panel1.Controls.Add(AAA);
        //Panel1.Controls.Add(DL3);
        
    }
}