using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CarSln
{
    public class Common
    {
        /// <summary>
        /// 显示窗体 flag表示传过来的窗体是否需要最大化 0,表示否
        /// </summary>
        public static void showFrm(Form frm, Form parentForm, int flag)
        {
            bool k = false;

            for (int i = 0; i < parentForm.MdiChildren.Length; i++)
            {
                if (parentForm.MdiChildren[i].Name.Equals(frm.Name))
                {
                    parentForm.MdiChildren[i].Activate();
                    //parentForm.LayoutMdi(MdiLayout.ArrangeIcons);

                    k = true;
                    break;
                }
            }
            if (!k)
            {
                frm.MdiParent = parentForm;
                MdiClient client = frm.Parent as MdiClient;
                frm.Location = new Point(0, 0);
                frm.StartPosition = FormStartPosition.Manual;
                if (flag == 0)
                {
                    frm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    Size s = client.ClientSize;
                    frm.Size = new Size(s.Width, s.Height);
                }
                // parentForm.LayoutMdi(MdiLayout.ArrangeIcons);
                frm.Show();
            }
        }
    }
}
