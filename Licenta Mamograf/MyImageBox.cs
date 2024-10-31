using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta_Mamograf
{
    internal class MyImageBox : PictureBox
    {

        public bool ROIselect_Button_active { get; set; } = false;



        private bool _panableAndZoomable;

        //
        // Summary:
        //     The zoom scale of the image to be displayed
        private double _zoomScale;

        public Point _mouseDownPosition;

        private MouseButtons _mouseDownButton;

        private Point _bufferPoint;

        private HScrollBar horizontalScrollBar;

        private VScrollBar verticalScrollBar;

        private InterpolationMode _interpolationMode = InterpolationMode.NearestNeighbor;

        private static readonly Cursor _defaultCursor = Cursors.Hand;

        //
        // Summary:
        //     The available zoom levels for the displayed image
        public static double[] ZoomLevels = new double[7] { 0.125, 0.25, 0.5, 1.0, 2.0, 4.0, 8.0 };

        //
        // Summary:
        //     Get or Set the property to enable(disable) Pan and Zoom
        protected bool PanableAndZoomable
        {
            get
            {
                return _panableAndZoomable;
            }
            set
            {
                if (_panableAndZoomable != value)
                {
                    _panableAndZoomable = value;
                    if (_panableAndZoomable)
                    {
                        base.MouseEnter += OnMouseEnter;
                        base.MouseWheel += OnMouseWheel;
                        base.MouseMove += OnMouseMove;
                        base.Resize += OnResize;
                        base.MouseDown += OnMouseDown;
                        base.MouseUp += OnMouseUp;
                    }
                    else
                    {
                        base.MouseEnter -= OnMouseEnter;
                        base.MouseWheel -= OnMouseWheel;
                        base.MouseMove -= OnMouseMove;
                        base.Resize -= OnResize;
                        base.MouseDown -= OnMouseDown;
                        base.MouseUp -= OnMouseUp;
                    }
                }
            }
        }

        //
        // Summary:
        //     Get or Set the interpolation mode for zooming operation
        [Bindable(false)]
        [Category("Design")]
        [DefaultValue(InterpolationMode.NearestNeighbor)]
        public InterpolationMode InterpolationMode
        {
            get
            {
                return _interpolationMode;
            }
            set
            {
                _interpolationMode = value;
            }
        }

        //
        // Summary:
        //     Get the horizontal scroll bar from this control
        [Browsable(false)]
        public HScrollBar HorizontalScrollBar => horizontalScrollBar;

        //
        // Summary:
        //     Get the vertical scroll bar of this control
        [Browsable(false)]
        public VScrollBar VerticalScrollBar => verticalScrollBar;

        //
        // Summary:
        //     Get or Set the zoom scale
        [Browsable(false)]
        public double ZoomScale => _zoomScale;

        //
        // Summary:
        //     The event to fire when the zoom scale is changed
        public event EventHandler OnZoomScaleChange;

        //
        // Summary:
        //     Create a picture box with pan and zoom functionality
        public MyImageBox()
        {
            InitializeComponent();
            _zoomScale = 1.0;
            SetScrollBarVisibilityAndMaxMin();
            base.ResizeRedraw = false;
            DoubleBuffered = true;
            PanableAndZoomable = true;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!ROIselect_Button_active)
            {
                _mouseDownPosition = e.Location;
                _mouseDownButton = e.Button;
                _bufferPoint = Point.Empty;
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _mouseDownButton = MouseButtons.None;
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (base.TopLevelControl is Form form)
            {
                form.ActiveControl = this;
            }
        }

        private void OnResize(object sender, EventArgs e)
        {
            Size viewSize = GetViewSize();
            if (base.Image != null && viewSize.Width > 0 && viewSize.Height > 0)
            {
                SetScrollBarVisibilityAndMaxMin();
                Invalidate();
            }
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            double num = 1.0;
            if (e.Delta > 0)
            {
                num = 2.0;
            }
            else
            {
                if (e.Delta == 0)
                {
                    return;
                }

                num = 0.5;
            }
            if (this.ZoomScale < 1 && num == 0.5)
                return;
            SetZoomScale(ZoomScale * num, e.Location);
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        //
        // Summary:
        //     Paint the image
        //
        // Parameters:
        //   pe:
        //     The paint event
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (base.IsDisposed)
            {
                return;
            }

            if (base.Image != null && (_zoomScale != 1.0 || (horizontalScrollBar.Visible && horizontalScrollBar.Value != 0) || (verticalScrollBar.Visible && verticalScrollBar.Value != 0)))
            {
                if (pe.Graphics.InterpolationMode != _interpolationMode)
                {
                    pe.Graphics.InterpolationMode = _interpolationMode;
                }

                Matrix matrix = pe.Graphics.Transform;
                if (_zoomScale != 1.0)
                {
                    matrix.Scale((float)_zoomScale, (float)_zoomScale, MatrixOrder.Append);
                }

                int num = (horizontalScrollBar.Visible ? (-horizontalScrollBar.Value) : 0);
                int num2 = (verticalScrollBar.Visible ? (-verticalScrollBar.Value) : 0);
                if (num != 0 || num2 != 0)
                {
                    matrix.Translate(num, num2);
                }

                pe.Graphics.Transform = matrix;
                base.OnPaint(pe);
                return;
            }

            base.OnPaint(pe);
        }

        private void SetScrollBarVisibilityAndMaxMin()
        {
            horizontalScrollBar.Visible = false;
            verticalScrollBar.Visible = false;
            if (base.Image != null)
            {
                horizontalScrollBar.Visible = (int)((double)base.Image.Size.Width * _zoomScale) > base.ClientSize.Width;
                verticalScrollBar.Visible = (int)((double)base.Image.Size.Height * _zoomScale) > base.ClientSize.Height;
                if (horizontalScrollBar.Visible)
                {
                    horizontalScrollBar.Maximum = base.Image.Size.Width - (int)((double)Math.Max(0, base.ClientSize.Width - (verticalScrollBar.Visible ? verticalScrollBar.Width : 0)) / _zoomScale);
                }
                else
                {
                    horizontalScrollBar.Maximum = 0;
                }

                horizontalScrollBar.LargeChange = Math.Max(horizontalScrollBar.Maximum / 10, 1);
                horizontalScrollBar.SmallChange = Math.Max(horizontalScrollBar.Maximum / 20, 1);
                if (verticalScrollBar.Visible)
                {
                    verticalScrollBar.Maximum = base.Image.Size.Height - (int)((double)Math.Max(0, base.ClientSize.Height - (horizontalScrollBar.Visible ? horizontalScrollBar.Height : 0)) / _zoomScale);
                }
                else
                {
                    verticalScrollBar.Maximum = 0;
                }

                verticalScrollBar.LargeChange = Math.Max(verticalScrollBar.Maximum / 10, 1);
                verticalScrollBar.SmallChange = Math.Max(verticalScrollBar.Maximum / 20, 1);
            }
        }

        //
        // Summary:
        //     Used for tracking the mouse position on the image
        //
        // Parameters:
        //   sender:
        //
        //   e:
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDownButton == MouseButtons.Left && (horizontalScrollBar.Visible || verticalScrollBar.Visible) && !ROIselect_Button_active)
            {
                int num = (int)((double)(e.X - _mouseDownPosition.X) / _zoomScale);
                int num2 = (int)((double)(e.Y - _mouseDownPosition.Y) / _zoomScale);
                if (num != 0 || num2 != 0)
                {
                    horizontalScrollBar.Value = Math.Max(Math.Min(horizontalScrollBar.Value - num, horizontalScrollBar.Maximum), horizontalScrollBar.Minimum);
                    verticalScrollBar.Value = Math.Max(Math.Min(verticalScrollBar.Value - num2, verticalScrollBar.Maximum), verticalScrollBar.Minimum);
                    if (num != 0)
                    {
                        _mouseDownPosition.X = e.Location.X;
                    }

                    if (num2 != 0)
                    {
                        _mouseDownPosition.Y = e.Location.Y;
                    }

                    Invalidate();
                }
            }
        }

        //
        // Summary:
        //     Get the size of the view area
        //
        // Returns:
        //     The size of the view area
        protected internal Size GetViewSize()
        {
            return new Size(base.ClientSize.Width - (verticalScrollBar.Visible ? verticalScrollBar.Width : 0), base.ClientSize.Height - (horizontalScrollBar.Visible ? horizontalScrollBar.Height : 0));
        }

        //
        // Summary:
        //     Get the size of the image
        //
        // Returns:
        //     The size of the image
        protected internal Size GetImageSize()
        {
            if (base.Image == null)
            {
                return default(Size);
            }

            Size size = base.Image.Size;
            return new Size((int)Math.Round((double)size.Width * _zoomScale), (int)Math.Round((double)size.Height * _zoomScale));
        }

        //
        // Summary:
        //     Get the minimum of the two sizes
        //
        // Parameters:
        //   s1:
        //     The first size
        //
        //   s2:
        //     The second size
        //
        // Returns:
        //     The minimum of the two sizes
        protected internal static Size Min(Size s1, Size s2)
        {
            return new Size((s1.Width < s2.Width) ? s1.Width : s2.Width, (s1.Height < s2.Height) ? s1.Height : s2.Height);
        }

        //
        // Summary:
        //     Draw a reversible rectangle on the control.
        //
        // Parameters:
        //   rect:
        //     The rectangle using the control's coordinate system
        public void DrawReversibleRectangle(Rectangle rect)
        {
            rect.Location = PointToScreen(rect.Location);
            ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Dashed);
        }

        private Rectangle GetRectanglePreserveAspect(Point p1, Point p2)
        {
            Rectangle rectangle = GetRectangle(p1, p2);
            Size size = Min(GetViewSize(), GetImageSize());
            if ((double)rectangle.Width / (double)rectangle.Height > (double)size.Width / (double)size.Height)
            {
                rectangle.Width = (int)((double)size.Width / (double)size.Height * (double)rectangle.Height);
            }
            else if ((double)rectangle.Width / (double)rectangle.Height < (double)size.Width / (double)size.Height)
            {
                rectangle.Height = (int)((double)rectangle.Width / (double)size.Width * (double)size.Height);
            }

            if (rectangle.Y != p2.Y)
            {
                rectangle.Y = p2.Y - rectangle.Height;
            }

            if (rectangle.X != p2.X)
            {
                rectangle.X = p2.X - rectangle.Width;
            }

            return rectangle;
        }

        //
        // Summary:
        //     Get the rectangle defined by the two points on the control
        //
        // Parameters:
        //   p1:
        //     The first point on the control
        //
        //   p2:
        //     The second point on the control
        //
        // Returns:
        //     the rectangle defined by the two points
        public Rectangle GetRectangle(Point p1, Point p2)
        {
            int num = Math.Min(p1.Y, p2.Y);
            int num2 = Math.Max(p1.Y, p2.Y);
            int num3 = Math.Min(p1.X, p2.X);
            int num4 = Math.Max(p1.X, p2.X);
            Size size = Min(GetViewSize(), GetImageSize());
            Rectangle result = new Rectangle(num3, num, num4 - num3, num2 - num);
            result.Intersect(new Rectangle(Point.Empty, size));
            return result;
        }

        //
        // Summary:
        //     Set the new zoom scale for the displayed image
        //
        // Parameters:
        //   zoomScale:
        //     The new zoom scale
        //
        //   fixPoint:
        //     The point to be fixed, in display coordinate
        public void SetZoomScale(double zoomScale, Point fixPoint)
        {
            if (base.Image != null && _zoomScale != zoomScale && (!(zoomScale < _zoomScale) || (!((double)base.Image.Size.Width * zoomScale < 2.0) && !((double)base.Image.Size.Height * zoomScale < 2.0))) && (!(zoomScale > _zoomScale) || (!((double)GetViewSize().Width < zoomScale * 2.0) && !((double)GetViewSize().Height < zoomScale * 2.0))))
            {
                fixPoint.X = Math.Min(fixPoint.X, (int)((double)base.Image.Size.Width * _zoomScale));
                fixPoint.Y = Math.Min(fixPoint.Y, (int)((double)base.Image.Size.Height * _zoomScale));
                int num = (int)((double)fixPoint.X * (zoomScale - _zoomScale) / zoomScale / _zoomScale);
                int num2 = (int)((double)fixPoint.Y * (zoomScale - _zoomScale) / zoomScale / _zoomScale);
                _zoomScale = zoomScale;
                int val = horizontalScrollBar.Value + num;
                int val2 = verticalScrollBar.Value + num2;
                SetScrollBarVisibilityAndMaxMin();
                horizontalScrollBar.Value = Math.Min(Math.Max(horizontalScrollBar.Minimum, val), horizontalScrollBar.Maximum);
                verticalScrollBar.Value = Math.Min(Math.Max(verticalScrollBar.Minimum, val2), verticalScrollBar.Maximum);
                Invalidate();
                if (this.OnZoomScaleChange != null)
                {
                    this.OnZoomScaleChange(this, new EventArgs());
                }
            }
        }

        private void InitializeComponent()
        {
            this.horizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.verticalScrollBar = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            base.SuspendLayout();
            this.horizontalScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalScrollBar.Location = new System.Drawing.Point(0, 0);
            this.horizontalScrollBar.Name = "horizontalScrollBar";
            this.horizontalScrollBar.Size = new System.Drawing.Size(80, 17);
            this.horizontalScrollBar.TabIndex = 2;
            this.horizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(OnScroll);
            base.Controls.Add(this.horizontalScrollBar);
            this.verticalScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.verticalScrollBar.Location = new System.Drawing.Point(0, 0);
            this.verticalScrollBar.Name = "verticalScrollBar";
            this.verticalScrollBar.Size = new System.Drawing.Size(17, 80);
            this.verticalScrollBar.TabIndex = 1;
            this.verticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(OnScroll);
            base.Controls.Add(this.verticalScrollBar);
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            base.ResumeLayout(false);
        }
    }
}
