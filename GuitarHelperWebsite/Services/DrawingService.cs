using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GuitarHelperWebsite.Services
{
    public class DrawingService
    {
        private NoteService noteService = new NoteService();
        private ScaleService scaleService = new ScaleService();
        private TuningService tuningService = new TuningService();

        private int width = 1000;
        private int height = 300;

        // Coordinates
        private float frets = 24;
        private float nutX = 44;
        private float neckLength;
        private float neckTop = 30;
        private float neckBottom = 230;
        private float fretNumberingY;
        private float openStringX;

        // Pens, Brushes, Fonts
        private Pen p = new Pen(Color.Black);
        private Brush b = Brushes.Black;
        private Brush highlightBrush = Brushes.Orange;
        private Brush clickHighlightBrush = Brushes.BurlyWood;
        private Font f = new Font("Helvetica", 10);
        
        public string GetDrawing(string tuning)
        {
            return GetDrawing(tuningService.GetTuning(tuning), new List<Note>());
        }

        public string GetDrawing(string tuning, string pattern, string note)
        {
            return GetDrawing(tuningService.GetTuning(tuning), scaleService.GetNotes(pattern, note));
        }

        public string GetDrawing(Tuning tuning, List<Note> notes)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, new Rectangle(new Point(0,0), new Size(width, height)));
                neckLength = width - nutX * 2;

                fretNumberingY = neckTop - 20;
                openStringX = nutX - 22;

                float stringDistance = 0;
                if (tuning.Notes != null)
                    stringDistance = (neckBottom - neckTop) / Convert.ToSingle(tuning.Notes.Count);

                float lastX = nutX;
                float endOfFretboard = FretLocation((int)frets);
                for (int i = 0; i <= frets; i++)
                {
                    float ratio = FretLocation(i) / endOfFretboard;
                    float x = nutX + ratio * neckLength;

                    if (i == 0)
                        x = nutX;

                    g.DrawString("" + i, f, b, new PointF(i == 0 ? openStringX : (lastX + x - g.MeasureString("" + i, f).Width) / 2f, fretNumberingY));

                    // If fret is matching note, print it
                    if (tuning.Notes != null)
                    {
                        for (int j = 0; j < tuning.Notes.Count; j++)
                        {
                            float stringY = neckTop + stringDistance * (j + 1);

                            // Draw String Separator
                            if (j != tuning.Notes.Count - 1)
                                g.DrawLine(p, new PointF(nutX, stringY), new PointF(nutX + neckLength, stringY));

                            Note fretNote = noteService.GetNote(tuning.Notes[j].Value + i);
                            if (notes.Contains(fretNote))
                            {
                                g.FillEllipse(highlightBrush,
                                    new RectangleF(
                                        (i == 0 ? openStringX - 6 : lastX) + 1,
                                        (neckTop + stringDistance * (j + 1)) - 1,
                                        (i == 0 ? (nutX + openStringX - 8) / 2f : x - lastX) - 2,
                                        (neckTop + stringDistance * (j) - stringY) + 2
                                    ));

                                //if (!ShowNotes && Match != null && Match.Notes.Contains(fretNote))
                                //    for (int index = 0; index < Match.Notes.Count; index++)
                                //        if (Match.Notes[index] == fretNote)
                                //            noteString = Match.Scale.Pattern.Split(new char[] { ',' })[index].ToString();

                                g.DrawString(fretNote.ToString(), f, b,
                                    new PointF(i == 0 ? openStringX :
                                        (lastX + x - g.MeasureString(fretNote.ToString(), f).Width) / 2f,
                                        stringY - stringDistance * .75f));
                            }
                        }
                    }

                    if (i != 0)
                        g.DrawLine(p, new PointF(x, neckTop), new PointF(x, neckBottom));

                    lastX = x;
                }

                // Fretboard outlines
                g.DrawLine(p, new PointF(nutX, neckTop), new PointF(nutX + neckLength, neckTop));
                g.DrawLine(p, new PointF(nutX, neckBottom), new PointF(nutX + neckLength, neckBottom));
                g.DrawLine(p, new PointF(nutX, neckTop), new PointF(nutX, neckBottom));
                g.DrawLine(p, new PointF(nutX + neckLength, neckTop), new PointF(nutX + neckLength, neckBottom));

                if (tuning.Notes != null)
                {
                    for (int j = 0; j < tuning.Notes.Count; j++)
                    {
                        float stringY = neckTop + stringDistance * (j + 1);

                        // Draw String Separator
                        if (j != tuning.Notes.Count - 1)
                            g.DrawLine(p, new PointF(nutX, stringY), new PointF(nutX + neckLength, stringY));

                        string note = tuning.Notes[j].ToString();
                        g.DrawString(note, f, b, new PointF(openStringX - 24, stringY - stringDistance * .75f));
                    }

                    g.DrawLine(p, new PointF(openStringX - 6, neckTop), new PointF(openStringX - 6, neckBottom));
                }
            }

            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Gif);
            return Convert.ToBase64String(ms.ToArray());
        }

        private float FretLocation(int fret)
        {
            return neckLength - (neckLength / Convert.ToSingle(Math.Pow(2, fret / 12f)));
        }
    }
}
