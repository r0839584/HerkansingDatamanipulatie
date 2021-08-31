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
                FileOperations.FoutLoggen(e);
                return 0;
            }
        }



        public static List<Genre> OphalenGenre()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                var query = entities.Genre;

                return query.ToList();
            }
        }

        public static List<Character> OphalenCharacters()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                var query = entities.Character.Where(x => x.characterId == HelperClass.characterId);
                return query.ToList();
            }
        }

        public static List<Author> OphalenAuthor()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                var query = entities.Author;
                return query.ToList();
            }
        }

        public static int ToevoegenManga(Manga manga)
        {
            try
            {
                using (Project_MALEntities entities = new Project_MALEntities())
                {
                    entities.Manga.Add(manga);
                    return entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                FileOperations.FoutLoggen(e);
                return 0;
            }
        }

        public static int ToevoegenCharacter(Character character)
        {
            try
            {
                using (Project_MALEntities entities = new Project_MALEntities())
                {
                    entities.Character.Add(character);
                    return entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                FileOperations.FoutLoggen(e);
                return 0;
            }
        }

        public static int ToevoegenMangaGenres(List<MangaGenre> mangaGenre)
        {
            try
            {
                using (Project_MALEntities entities = new Project_MALEntities())
                {
                    entities.MangaGenre.AddRange(mangaGenre);
                    return entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                FileOperations.FoutLoggen(e);
                return 0;
            }
        }

        public static Manga OphalenMangaAuthorViaId()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                return entities.Manga
                    .Include(x => x.Characters)
                    .Include(x => x.Author)
                    .Where(x => x.mangaId == HelperClass.mangaId)
                    .SingleOrDefault();
            }
        }
                                   
        public static Character OphalenMangaCharacters()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                return entities.Character.Where(x => x.characterId == HelperClass.characterId).SingleOrDefault();
            }
        }

        public static int VerwijderenCharacter(Character character)
        {
            try
            {
                using (Project_MALEntities entities = new Project_MALEntities())
                {
                    entities.Entry(character).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                FileOperations.FoutLoggen(e);
                return 0;
            }
        }

        public static int VerwijderenMangaGenre(MangaGenre mangaGenre)
        {
            try
            {
                using (Project_MALEntities entities = new Project_MALEntities())
                {
                    entities.Entry(mangaGenre).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                FileOperations.FoutLoggen(e);
                return 0;
            }
        }

        public static List<Genre> OphalenMangaGenre()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                var query = entities.Genre.Include(x => x.MangaGenres);

                return query.ToList();
            }
        }

        //public static Manga OphalenMangaGenres()
        //{
        //    using (Project_MALEntities entities = new Project_MALEntities())
        //    {
        //        return entities.Manga.Include(x => x.MangaGenres.Select(sub => sub.Genre)).SingleOrDefault();
        //    }
        //}

        public static List<MangaGenre> OphalenMangaGenres()
        {
            using (Project_MALEntities entities = new Project_MALEntities())
            {
                // 
                var query = entities.MangaGenre.Include(x => x.Genre).Include(x => x.Manga).Where(x => x.mangaId == HelperClass.mangaId);
                return query.ToList();
            }
        }



        //public static Genre OphalenGenreDoorGenreId(int? genreId)
        //{
        //    using (Project_MALEntities entities = new Project_MALEntities())
        //    {
        //        var query = entities.Genre.Where(x => x.genreId == genreId);
        //        return query.SingleOrDefault();
        //    }
        //}
    }
}
