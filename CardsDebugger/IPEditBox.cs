using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Wangfs763.Cards
{
    /// <summary>
    /// IP编辑框
    /// </summary>
    sealed class IPEditBox : TextBox
    {
        public IPEditBox() { base.Text = "0.0.0.0"; }

        private IPAddress m_IP;
        [Browsable(false), DefaultValue(typeof(IPAddress), "0.0.0.0")]
        public IPAddress IP
        {
            get { return this.m_IP; }
            set { base.Text = (this.m_IP = value) == null ? "" : value.ToString(); }
        }

        [DefaultValue("0.0.0.0")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                IPAddress ip;
                if (!IPAddress.TryParse(value, out ip)) return;
                this.m_IP = ip;
                base.Text = value;
            }
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            string txt;
            int tmp = this.SelectionStart, idx;
            byte v;
            switch (e.KeyChar)
            {
                case '\r':  // enter
                    break;
                case '\b':  // back space
                    if (this.SelectionLength > 0)
                    {
                        // 删除选中的内容
                        if (this.SelectionLength < this.TextLength)
                        {
                            // 不是全选
                            if (this.SelectionStart > 0)
                            {
                                // 不是从开头选
                                if (e.Handled = this.SelectionStart + this.SelectionLength == this.TextLength)
                                {
                                    // 选到结尾
                                    base.Text = base.Text[this.SelectionStart - 1] == '.' ? base.Text.Substring(0, this.SelectionStart - 1) : base.Text.Substring(0, this.SelectionStart);
                                    this.SelectionStart = tmp;
                                    return;
                                }
                                else
                                {
                                    // 选中间部分
                                    idx = base.Text.LastIndexOf('.', this.SelectionStart);
                                    txt = idx < 0 ? base.Text.Substring(0, this.SelectionStart) : base.Text.Substring(idx + 1, this.SelectionStart - idx - 1);
                                    int start = this.SelectionStart + this.SelectionLength;
                                    idx = base.Text.IndexOf('.', start);
                                    txt += idx < 0 ? base.Text.Substring(start) : base.Text.Substring(start, idx - start);
                                    if (e.Handled = txt == "")
                                    {
                                        // 选择了某个段
                                        base.Text = base.Text.Substring(0, this.SelectionStart - 1) + base.Text.Substring(this.SelectionStart + this.SelectionLength);
                                        this.SelectionStart = tmp;
                                        return;
                                    }
                                    else
                                    {
                                        if (e.Handled = !byte.TryParse(txt, out v)) return;
                                    }
                                }
                            }
                            else
                            {
                                // 选开头部分
                                if (e.Handled = base.Text[this.SelectionLength] == '.')
                                {
                                    base.Text = base.Text.Substring(this.SelectionLength);
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.SelectionStart > 0)
                        {
                            // 删除光标前的字符
                            if (this.SelectionStart == 1)
                            {
                                // 删第一个
                                if (this.TextLength == 1) return;
                                if (e.Handled = base.Text[this.SelectionStart] == '.') base.Text = base.Text.Substring(2);
                                return;
                            }
                            if (this.SelectionStart == this.TextLength)
                            {
                                // 删最后一个
                                if (e.Handled = base.Text[this.SelectionStart - 2] == '.')
                                {
                                    base.Text = base.Text.Substring(0, this.SelectionStart - 2);
                                    this.SelectionStart = this.TextLength;
                                }
                                return;
                            }
                            // 删中间某个
                            if (e.Handled = base.Text[this.SelectionStart - 2] == '.' && base.Text[this.SelectionStart] == '.')
                            {
                                base.Text = base.Text.Substring(0, this.SelectionStart - 2) + base.Text.Substring(this.SelectionStart);
                                this.SelectionStart = tmp - 2;
                                return;
                            }
                            if (e.Handled = base.Text[this.SelectionStart - 1] == '.') return;
                        }
                    }
                    break;
                case '.':
                    if (this.SelectionLength > 0)
                    {
                        // 有选中内容
                        if (e.Handled = this.TextLength == this.SelectionLength)
                        {
                            // 全选
                            base.Text = "";
                            return;
                        }
                        if (e.Handled = this.SelectionStart == 0)
                        {
                            // 开头部分被选中
                            base.Text = base.Text.Substring(this.SelectionLength);
                            return;
                        }
                        if (this.SelectionLength + this.SelectionStart == this.TextLength)
                        {
                            // 选中尾部部分
                            e.Handled = base.Text[this.SelectionStart - 1] == '.';
                            return;
                        }
                        // 中间
                        if (e.Handled = base.Text[this.SelectionStart - 1] == '.' || base.Text[this.SelectionStart + this.SelectionLength] == '.')
                        {
                            base.Text = (base.Text.Substring(0, this.SelectionStart) + base.Text.Substring(this.SelectionStart + this.SelectionLength)).Replace("..", ".");
                            this.SelectionStart = tmp;
                            return;
                        }
                        if (e.Handled = base.Text.Count((c) => c == '.') == 3)
                        {
                            base.Text = base.Text.Substring(0, this.SelectionStart) + base.Text.Substring(this.SelectionStart + this.SelectionLength);
                            this.SelectionStart = tmp;
                        }
                    }
                    else
                    {
                        // 没有选中内容
                        if (e.Handled = this.TextLength == 0 || this.SelectionStart == 0) return;
                        if (e.Handled = base.Text[this.SelectionStart - 1] == '.') return;
                        if (e.Handled = this.SelectionStart < this.TextLength && base.Text[this.SelectionStart] == '.') this.SelectionStart++;
                        if (e.Handled = base.Text.Count((c) => c == '.') == 3) this.SelectionStart++;
                    }
                    break;
                case ' ':   // 空格
                    e.Handled = true;
                    this.SelectionStart++;
                    break;
                default:
                    if (!char.IsNumber(e.KeyChar))
                    {
                        e.Handled = true;
                        return;
                    }
                    // 数字
                    if (this.SelectionLength > 0)
                    {
                        // 有选中内容
                        if (this.SelectionLength == this.TextLength) return;
                        if (this.SelectionStart == 0)
                        {
                            // 选中开头
                            if (base.Text[this.SelectionLength] != '.')
                            {
                                // 紧接着数字
                                int i = base.Text.IndexOf('.', this.SelectionLength);
                                e.Handled = !byte.TryParse(e.KeyChar + base.Text.Substring(this.SelectionLength, (i > 0 ? i : this.TextLength) - this.SelectionLength), out v);
                            }
                            return;
                        }
                        if (this.SelectionStart + this.SelectionLength == this.TextLength)
                        {
                            // 选中尾部
                            if (base.Text[this.SelectionStart - 1] != '.')
                            {
                                idx = base.Text.LastIndexOf('.', this.SelectionStart - 1);
                                e.Handled = !byte.TryParse(base.Text.Substring(idx + 1, this.SelectionStart - idx - 1) + e.KeyChar, out v);
                            }
                            return;
                        }
                        // 中间
                        idx = base.Text.LastIndexOf('.', this.SelectionStart);
                        txt = idx < 0 ? base.Text.Substring(0, this.SelectionStart) : base.Text.Substring(idx + 1, this.SelectionStart - idx - 1);
                        int start = this.SelectionStart + this.SelectionLength;
                        txt += e.KeyChar + base.Text.Substring(start, base.Text.IndexOf('.', start) - start);
                        if (e.Handled = !byte.TryParse(txt, out v))
                        {
                        }
                    }
                    else
                    {
                        if (this.SelectionStart == 0)
                        {
                            // 在第一位输入
                            idx = base.Text.IndexOf('.');
                            if (idx < 0)
                            {
                                txt = e.KeyChar + base.Text;
                                if (e.Handled = !byte.TryParse(txt, out v))
                                {
                                    txt = e.KeyChar + base.Text.Substring(1);
                                    if (!byte.TryParse(txt, out v)) base.Text = base.Text.Substring(1);
                                    else base.Text = txt;
                                    this.SelectionStart = 1;
                                }
                            }
                            else
                            {
                                txt = e.KeyChar + base.Text.Substring(0, idx);
                                if (e.Handled = !byte.TryParse(txt, out v))
                                {
                                    txt = e.KeyChar + base.Text.Substring(1, idx - 1);
                                    if (!byte.TryParse(txt, out v)) base.Text = base.Text.Substring(1);
                                    else base.Text = txt + base.Text.Substring(idx + 1);
                                    this.SelectionStart = 1;
                                }
                            }
                            return;
                        }
                        if (this.SelectionStart == this.TextLength)
                        {
                            // 在末尾输入
                            idx = base.Text.LastIndexOf('.');
                            if (idx < 0)
                            {
                                // 第一段
                                txt = base.Text + e.KeyChar;
                                if (e.Handled = !byte.TryParse(txt, out v))
                                {
                                    base.Text += "." + e.KeyChar;
                                    this.SelectionStart = this.TextLength;
                                }
                                return;
                            }
                            else
                            {
                                // 非首段
                                txt = base.Text.Substring(idx + 1) + e.KeyChar;
                                if (e.Handled = !byte.TryParse(txt, out v))
                                {
                                    if (base.Text.Count((c) => c == '.') == 3)
                                    {
                                        txt = base.Text.Substring(idx + 1, this.TextLength - idx - 2) + e.KeyChar;
                                        if (byte.TryParse(txt, out v)) base.Text = base.Text.Substring(0, idx) + '.' + txt;
                                    }
                                    else base.Text += "." + e.KeyChar;
                                    this.SelectionStart = this.TextLength;
                                }
                            }
                            return;
                        }
                        // 中间位置输入
                        idx = base.Text.LastIndexOf('.', this.SelectionStart - 1);
                        if (idx < 0)
                        {
                            txt = base.Text.Substring(0, this.SelectionStart) + e.KeyChar;
                            idx = base.Text.IndexOf('.', this.SelectionStart);
                            if (idx < 0)
                            {
                                txt = base.Text.Insert(this.SelectionStart, e.KeyChar.ToString());
                                if (e.Handled = !byte.TryParse(txt, out v)) this.SelectionStart++;
                            }
                            else
                            {
                                txt += base.Text.Substring(this.SelectionStart, idx - this.SelectionStart);
                                if (e.Handled = !byte.TryParse(txt, out v)) this.SelectionStart++;
                            }
                        }
                        else
                        {
                            tmp = base.Text.IndexOf('.', this.SelectionStart);
                            if (tmp < 0)
                            {
                                txt = base.Text.Substring(idx + 1, this.SelectionStart - idx - 1) + e.KeyChar + base.Text.Substring(this.SelectionStart);
                                if (e.Handled = !byte.TryParse(txt, out v)) this.SelectionStart++;
                            }
                            else
                            {
                                txt = base.Text.Substring(idx + 1, this.SelectionStart - idx - 1) + e.KeyChar + base.Text.Substring(this.SelectionStart, tmp - this.SelectionStart);
                                if (e.Handled = !byte.TryParse(txt, out v)) this.SelectionStart++;
                            }
                        }
                    }
                    break;
            }

        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (this.Text.EndsWith(".")) this.Text = this.Text.Substring(0, this.TextLength - 1);
            this.m_IP = this.TextLength > 0 ? IPAddress.Parse(this.Text) : null;
            base.OnValidating(e);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 646)
            {
                base.DefWndProc(ref m);
                return;
            }   // 258
            base.WndProc(ref m);
        }
    }
}
