using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test111
{
    /// <summary>
    ///  Унаследованый от DataGridView класс, 
    ///  в котором просто получаем доступ к protected свойству 
    /// </summary>
    //[Description("Data Grid View с установленым свойством DoubleBuffered = true")]
    public class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            this.Anchor= (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            this.AllowUserToAddRows = false;
            // и устанавливаем значение true при создании экземпляра класса
            this.DoubleBuffered = true;
            // или с помощью метода SetStyle
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
    }
}
