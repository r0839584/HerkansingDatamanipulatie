//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_MAL_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MangaGenre
    {
        public int mangaGenreId { get; set; }
        public int mangaId { get; set; }
        public Nullable<int> genreId { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Manga Manga { get; set; }
    }
}
