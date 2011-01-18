/*
PictureSorter is a program that assists in the orientation, resizing, and
renaming of images.

Copyright (C) 2009-2011 Adam Milazzo
http://www.adammil.net/

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PictureSorter
{

partial class CropImageForm : Form
{
  public CropImageForm()
  {
    InitializeComponent();
  }

  public CropImageForm(Image initialImage) : this()
  {
    overlay.Image = initialImage;
  }

  /// <summary>Gets the final image created by the user.</summary>
  public Image Image
  {
    get { return newImage; }
  }

  /// <include file="documentation.xml" path="/UI/Common/OnMouseDown/*"/>
  protected override void OnMouseDown(MouseEventArgs e)
  {
    base.OnMouseDown(e);
    OnMouseDown(e.Button, e.Location);
  }

  /// <include file="documentation.xml" path="/UI/Common/OnMouseMove/*"/>
  protected override void OnMouseMove(MouseEventArgs e)
  {
    base.OnMouseMove(e);
    OnMouseMove(e.Location);
  }

  /// <include file="documentation.xml" path="/UI/Common/OnMouseUp/*"/>
  protected override void OnMouseUp(MouseEventArgs e)
  {
    base.OnMouseUp(e);
    OnMouseUp(e.Button, e.Location);
  }

  #region OverlayControl
  /// <summary>A control that displays a image and an optional selection area overlayed on top of it.</summary>
  sealed class OverlayControl : Control
  {
    public OverlayControl()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer,
               true);
    }

    /// <summary>Gets or sets the image shown in the overlay control. Setting this will reset the
    /// <see cref="ImageRect"/> property.
    /// </summary>
    [Browsable(false)]
    [DefaultValue(null)]
    public Image Image
    {
      get { return image; }
      set
      {
        image = value;
        if(value != null) imageRect = new RectangleF(0, 0, value.Width, value.Height);
      }
    }

    /// <summary>Gets or sets the region of the image shown in the overlay control, in image coordinates.</summary>
    [Browsable(false)]
    public RectangleF ImageRect
    {
      get { return imageRect; }
      set
      {
        imageRect = value;
        Invalidate();
      }
    }

    /// <summary>Gets whether a region of the image is selected with an overlay rectangle.</summary>
    [Browsable(false)]
    public bool HasOverlay
    {
      get
      {
        RectangleF overlay = RectangleF.Intersect(OverlayRect, GetImageDestinationRect());
        return overlay.Width >= 1 && overlay.Height >= 1;
      }
    }

    /// <summary>Gets or sets the region of the control covered with the overlay rectangle, in client units.</summary>
    public RectangleF OverlayRect
    {
      get { return overlayRect; }
      set
      {
        overlayRect = value;
        Invalidate();
      }
    }

    /// <summary>Retrieves the region of the image selected with an overlay rectangle, in image coordinates.</summary>
    public RectangleF GetImageOverlay()
    {
      RectangleF imageDest = GetImageDestinationRect(); // get the region of the control with the image on it
      // get the portion of the overlay within the image
      RectangleF overlay = RectangleF.Intersect(OverlayRect, GetImageDestinationRect());
      // get a scale factor to convert from screen pixels to image pixels
      float xScale = imageRect.Width / imageDest.Width, yScale = imageRect.Height / imageDest.Height;
      return new RectangleF((overlay.X - imageDest.X) * xScale + imageRect.X,
                            (overlay.Y - imageDest.Y) * yScale + imageRect.Y,
                            overlay.Width * xScale, overlay.Height * yScale);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      // draw the background image
      if(image != null)
      {
        RectangleF destRect = GetImageDestinationRect();
        e.Graphics.DrawImage(image, destRect, imageRect, GraphicsUnit.Pixel);

        // draw the overlay rectangle
        RectangleF overlay = RectangleF.Intersect(OverlayRect, destRect);
        if(overlay.Width != 0 && overlay.Height != 0)
        {
          using(Brush brush = new SolidBrush(Color.FromArgb(112, 0, 0, 255)))
          {
            e.Graphics.FillRectangle(brush, overlay);
          }
          e.Graphics.DrawRectangle(Pens.Blue, overlay.X, overlay.Y, overlay.Width-1, overlay.Height-1);
        }
      }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      Invalidate();
    }

    /// <summary>Gets the region of the overlay control onto which the image will be painted.</summary>
    RectangleF GetImageDestinationRect()
    {
      RectangleF destRect = ClientRectangle; // begin with the whole client area

      float srcAspect = (float)imageRect.Width/imageRect.Height, destAspect = (float)destRect.Width/destRect.Height;
      if(srcAspect > destAspect) // the image has a wider aspect than the control
      {
        if(imageRect.Width > destRect.Width) // and if the image region is physically wider, then let the image fill
        {                                    // the control horizontally, and we'll reduce the height
          destRect.Height = destRect.Width / srcAspect;
        }
        else // otherwise, the image region fits within the control, so use the size as-is
        {
          destRect.Size = imageRect.Size;
        }
      }
      else // the image has a taller (or equal) aspect
      {
        if(imageRect.Height > destRect.Height) // since the aspect is taller, we have to test the height first
        {
          destRect.Width = destRect.Height * srcAspect;
        }
        else
        {
          destRect.Size = imageRect.Size;
        }
      }

      // now center the image within the control
      destRect.Offset((Width - destRect.Width) * 0.5f, (Height - destRect.Height) * 0.5f);

      return destRect;
    }

    Image image;
    RectangleF imageRect, overlayRect;
  }
  #endregion

  /// <summary>Called when a drag of the overlay rectangle is canceled.</summary>
  void CancelDrag()
  {
    ResetOverlayRect();
    FinishDrag();
  }

  /// <summary>Called when a drag of the overlay rectangle is complete.</summary>
  void FinishDrag()
  {
    dragging = mouseDown = false;
  }

  /// <summary>Called when a mouse button is depressed within the form or any of its controls, and passed the mouse
  /// button and the location in the form's client units.
  /// </summary>
  void OnMouseDown(MouseButtons button, Point location)
  {
    if(button == MouseButtons.Left)
    {
      mouseDown = true;  // the mouse button is pressed
      dragging  = false; // but we're not dragging yet
      dragRect  = new Rectangle(PointToOverlay(location), new Size()); // start a new drag rectangle from this point
      SetOverlayRect(dragRect); // and reset the drag rectangle
    }
  }

  /// <summary>Called when a mouse is moved over the form or any of its controls, and passed the new cursor location
  /// in form client units.
  /// </summary>
  void OnMouseMove(Point location)
  {
    if((Control.MouseButtons & MouseButtons.Left) == 0) // if the left mouse button is not depressed
    {
      if(dragging) FinishDrag(); // if we're still dragging, then we missed the mouse up event somehow (because this
    }                            // method is not actually called for every control on the form...)
    else if(mouseDown) // otherwise, if the mouse button was pressed over the control
    {
      location = PointToOverlay(location); // calculate the distance from where it was first depressed
      int xd = location.X - dragRect.X, yd = location.Y - dragRect.Y;

      if(!dragging && xd*xd + yd*yd >= 4) dragging = true; // if we're not dragging, but the point has moved a bit,
                                                           // then start dragging
      if(dragging) // if we're dragging now (possibly just started)...
      {
        dragRect.Width  = xd; // then update the dimensions of the drag rectangle
        dragRect.Height = yd;

        // create a copy of the current drag rectangle, and fix up the coordinates if the width and/or height are
        // negative, caused by the user dragging the mouse above or to the left of the start position
        Rectangle overlayRect = dragRect;
        if(overlayRect.Width < 0)
        {
          overlayRect.X    += overlayRect.Width;
          overlayRect.Width = -overlayRect.Width;
        }

        if(overlayRect.Height < 0)
        {
          overlayRect.Y     += overlayRect.Height;
          overlayRect.Height = -overlayRect.Height;
        }

        // now set the new overlay rectangle
        SetOverlayRect(overlayRect);
      }
    }
  }

  /// <summary>Called when the mouse is released over the form or any of its controls, and passed the button released
  /// and the location in the form's client units.
  /// </summary>
  void OnMouseUp(MouseButtons button, Point location)
  {
    if(dragging) // if we were dragging...
    {
      if((Control.MouseButtons & MouseButtons.Left) == 0) // but now the left mouse button is no longer depressed,
      {                                                   // either because it was released just now or earlier, then
        OnMouseMove(location);                            // finish the drag
        FinishDrag();
      }
    }
    else if(button == MouseButtons.Left) // otherwise, we weren't dragging, so if it was the left button, then this is
    {                                    // just a click, which will clear the drag rectangle
      CancelDrag();
    }
  }

  /// <summary>Coverts a point from the form's client units to the overlay control's client units.</summary>
  Point PointToOverlay(Point pt)
  {
    return new Point(pt.X - overlay.Left, pt.Y - overlay.Top);
  }

  /// <summary>Removes the overlay rectangle.</summary>
  void ResetOverlayRect()
  {
    SetOverlayRect(new Rectangle());
  }

  /// <summary>Given a image size, and a maximum width and height, returns a size that fits within the maximums while
  /// preserving the original image's aspect ratio.
  /// </summary>
  Size ResizeImage(SizeF imageSize, int maxWidth, int maxHeight)
  {
    float aspectRatio = imageSize.Width / imageSize.Height, boxAspect = (float)maxWidth / maxHeight;
    Size newSize = Size.Round(imageSize);

    if(aspectRatio > boxAspect) // if the image aspect is wider than the box aspect...
    {
      if(newSize.Width > maxWidth) // and the image is wider too, then shrink it.
      {
        newSize.Width  = maxWidth;
        newSize.Height = (int)Math.Round(maxWidth / aspectRatio);
      }
    }
    else // the image aspect is taller than or equal to the box aspect
    {
      if(newSize.Height > maxHeight)
      {
        newSize.Width  = (int)Math.Round(maxHeight * aspectRatio);
        newSize.Height = maxHeight;
      }
    }

    return newSize;
  }

  void SetOverlayRect(Rectangle rect)
  {
    overlay.OverlayRect = rect;
    btnCrop.Enabled = rect.Width != 0;
  }

  void btnCrop_Click(object sender, EventArgs e)
  {
    imageRects.Add(overlay.ImageRect); // before the image is cropped, save the previous image rectangle so the user
    btnUndo.Enabled = btnDone.Enabled = true;      // can undo the cropping, or finish it
    overlay.ImageRect = overlay.GetImageOverlay(); // then set the image rect to the overlay rect
    ResetOverlayRect();
  }

  void btnDone_Click(object sender, EventArgs e)
  {
    RectangleF imageRect = overlay.ImageRect;

    Size newSize = Size.Round(imageRect.Size);

    // then create the final image
    Bitmap image = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb);
    if(overlay.Image.PixelFormat == PixelFormat.Format1bppIndexed ||
       overlay.Image.PixelFormat == PixelFormat.Format4bppIndexed ||
       overlay.Image.PixelFormat == PixelFormat.Format8bppIndexed)
    {
      image.Palette = overlay.Image.Palette; // copy the palette, if there is one
    }

    image.SetResolution(overlay.Image.HorizontalResolution, overlay.Image.VerticalResolution);

    using(Graphics g = Graphics.FromImage(image)) // and blit the original image into the final bitmap
    {
      g.CompositingMode    = CompositingMode.SourceCopy;
      g.CompositingQuality = CompositingQuality.HighQuality;
      g.InterpolationMode  = InterpolationMode.HighQualityBicubic;
      g.DrawImage(overlay.Image, new RectangleF(0, 0, image.Width, image.Height), imageRect, GraphicsUnit.Pixel);
    }

    newImage = image;
    DialogResult = DialogResult.OK;
  }

  void btnUndo_Click(object sender, EventArgs e)
  {
    overlay.ImageRect = imageRects[imageRects.Count-1]; // restore the previous image rectangle
    ResetOverlayRect();                                 // reset the overlay rectangle
    imageRects.RemoveAt(imageRects.Count-1);            // remove the previous image rectangle from the undo list
    btnUndo.Enabled = btnDone.Enabled = imageRects.Count != 0; // and update the Enabled state of "Undo" and "Done"
  }

  void control_MouseDown(object sender, MouseEventArgs e)
  {
    OnMouseDown(e.Button, PointToClient(((Control)sender).PointToScreen(e.Location)));
  }

  void control_MouseMove(object sender, MouseEventArgs e)
  {
    OnMouseMove(PointToClient(((Control)sender).PointToScreen(e.Location)));
  }

  void control_MouseUp(object sender, MouseEventArgs e)
  {
    OnMouseUp(e.Button, PointToClient(((Control)sender).PointToScreen(e.Location)));
  }

  void CropImageForm_KeyDown(object sender, KeyEventArgs e)
  {
    if(e.KeyCode == Keys.F1 && e.Modifiers == Keys.None) Program.ShowHelp();
  }

  List<RectangleF> imageRects = new List<RectangleF>();
  Image newImage;
  Rectangle dragRect;
  bool dragging, mouseDown;
}

} // namespace PictureSorter