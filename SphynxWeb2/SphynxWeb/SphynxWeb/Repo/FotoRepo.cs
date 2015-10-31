using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

using SphynxWeb.Models;
using SphynxWeb.Models.ViewModel;

namespace SphynxWeb.Repo
{
    public class FotoRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<FotoModel> GetAllFotos()
        {
            return db.Fotos.AsNoTracking();
        }

        public FotoModel GetFotoById(int id)
        {
            return db.Fotos.Find(id);
        }

        public void EditFotoModel(FotoModel foto)
        {
            db.Entry(foto).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool DeleteFoto(int id)
        {
            FotoModel foto = db.Fotos.Find(id);
            db.Fotos.Remove(foto);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        //public void AddFoto(FotoModel foto)
        //{
        //    db.Fotos.Add(foto);
        //    db.SaveChanges();
        //}

        //public byte[] GetImageBytes(int id)
        //{
        //    var cos = db.Fotos.Where(img => img.FotoId == id).Select(img => img.FotoData).First();
        //    return cos;
        //}

        public int UploadImageInDataBase(HttpPostedFileBase file, FotoModel fotoModel)
        {
            //    fotoModel.FotoData = ConvertToBytes(file);
            Image sourceimage = Image.FromStream(file.InputStream);
            fotoModel.FotoData = ConvertImageToBytes(sourceimage);

            var min = ScaleImage(sourceimage, 300, 300);
            fotoModel.FotoMiniatureData = ConvertImageToBytes(min);

            var foto = new FotoModel
            {
                FotoSize = file.ContentLength,
                Description = fotoModel.Description,
                FileName = fotoModel.FileName,
                FotoData = fotoModel.FotoData,
                FotoMiniatureData = fotoModel.FotoMiniatureData
            };
            db.Fotos.Add(foto);
            int i = db.SaveChanges();
            return i == 1 ? 1 : 0;
        }

        public static byte[] ConvertImageToBytes(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }

        public List<FotoModelView> DisplayFotoModelViews(IQueryable<FotoModel> fotoModel)
        {
            List<FotoModelView> viewFotos = new List<FotoModelView>();
            foreach (var item in fotoModel)
            {
                viewFotos.Add(

                    new FotoModelView
                    {
                        FotoId = item.FotoId,
                        FotoSize = item.FotoSize,
                        Description = item.Description,
                        FileName = item.FileName,
                        FotoData = "data:image/png;base64," + Convert.ToBase64String(item.FotoData),
                        FotoMiniatureData = "data:image/png;base64," + Convert.ToBase64String(item.FotoMiniatureData)
                    }
                );
            }


            return viewFotos;
        }
    }
}