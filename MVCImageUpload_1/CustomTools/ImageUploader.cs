using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO; //System Input Output... C#in Bilgisayar dosyalarına erişimini saglar

namespace MVCImageUpload_1.CustomTools
{

    //HttpPostedFileBase => MVC'de eger Post yönteminde bir dosya geliyorsa bu dosya, HttpPostedFileBase tipinde tutulur...
    public static class ImageUploader
    {

        public static string UploadImage(string serverPath,HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid(); //bu Metot size Bilgisayarınızın Mac adresini, ip adresini, timezone'ununu ve oturumda bulunan kullanıcı bilgilerini alıp harmanlayarak işletim sisteminize göre 36 karakterlik veya 38 karakterlik bir şifre döndürür...

                // asdad.asdsadasd.starWarsUzayGemisi.png
                // uzaygemisi.jpg
                // sovalye.gif

                string[] fileArray = file.FileName.Split('.'); //burada split metodu sayesinde ilgili yapının uzantısının da iceride bulundugu bir string dizisi almıs olduk...Split metodu belirttiginiz char karakterinden metni bölerek size bir array sunar...

                string extension = fileArray[fileArray.Length - 1].ToLower(); //dosya uzantsını yakalayarak kücük harflere cevirdik...

                string fileName = $"{uniqueName}.{extension}"; //normal şartlarda biz burada Guid kullandıgımız icin asla bir dosya ismi aynı olmayacaktır... Lakin siz Guid veya stable bir uniqueName Generator kullanmazsanız (kullanıcıya yüklemek istedigi dosyanın ismini verme konusunda serbestlik tanıma yaparsanız) aynı zamanda bir baska kontrol mekanizması acılarak veritabanınızda imagePath'lerde o isim var mı diye sorgulayıp sadece yoksa devam etmelisiniz...Bunu öncelikle extension'i kontrol edip sonra yapmalısınız...
                  
                if(extension=="jpg"||extension =="gif"||extension =="jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "1"; //Ancak Guid kullandıgımız icin bu acıdan zaten güvendeyiz(Dosya var kodu)
                    }

                    string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                    file.SaveAs(filePath);
                    return serverPath + fileName;
                }

                return "2";//Secilen dosya bir resim degildir


            }




            return "3"; //Dosya bos kodu
        }
    }
}