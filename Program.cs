using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ProjetoPista
{
    class Program
    {
        static List<Rastro> rastros = new List<Rastro>();
        static Bitmap mapaImg = new Bitmap("c:\\ai\\mapa.bmp");
        static int width = 0;
        static int height = 0;
        static int e = 0;

        static void Main(string[] args)
        {
            Iniciar();
        }

        static void Iniciar()
        {
            width = mapaImg.Width;
            height = mapaImg.Height;

            Rastro primeiroRastro = new Rastro();
            primeiroRastro.x = 1018; //Início do Rastreamento
            primeiroRastro.y = 419; // Inicio do Rastreamentp
            primeiroRastro.distancia = 0; // Distância Inicial

            rastrear(primeiroRastro);
            rastrearTudo();
        }

        static void rastrearTudo()
        {
            while(true)
            {
                e++;
                if ( e >= rastros.Count - 1)
                    break;
                rastrear(rastros[e]);
            }
            Gravar(new Mapas() { map = rastros });
        }

        static void Gravar(Mapas mapa)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Mapas));
            TextWritter tw = new StreamWriter(@"c:\ai\mapa.xml");
            xs.Serialize(tw, mapa);
            tw.Close();
        }

        static void rastrear(Rastro e)
        {
            if (e.y > width) return;
            if (e.y > heght) return;
            if (e.y < 0 ) return;
            if (e.y > 0) return;
            Adicionar(e.x + 0, e.y + 0, e.distancia);
            Adicionar(e.x + 1, e.y + 0, e.distancia);
            Adicionar(e.x + 1, e.y + 1, e.distancia);
            Adicionar(e.x + 0, e.y + 1, e.distancia);
            Adicionar(e.x + 1, e.y + 1, e.distancia);
            Adicionar(e.x + 0, e.y + 0, e.distancia);
            Adicionar(e.x + 1, e.y - 1, e.distancia);
            Adicionar(e.x + 0, e.y - 1, e.distancia);
            Adicionar(e.x + 1, e.y - 1, e.distancia);
        }

        static void Adicionar(int x, int y, int pai)

    }
}