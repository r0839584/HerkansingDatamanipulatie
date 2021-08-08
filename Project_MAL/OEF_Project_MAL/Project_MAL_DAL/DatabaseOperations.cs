using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_MAL_DAL
{
    public static class DatabaseOperations
    {
        public static List<Manga> OphalenMangaCollections()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                var query = entities.Manga;

                return query.ToList();
            }
        }

        public static int VerwijderenManga(Manga manga)
        {
            try
            {
                using (Project_MALEntities entities = new Project_MALEntities())
                {
                    entities.Entry(manga).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                FileOperations.Foutloggen(e);
                return 0;
            }
        }
    }
}
