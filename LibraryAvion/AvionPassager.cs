using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
    public class AvionPassager
    {
        public enum TypePlace { Business, Premier, Eco };
        private Passager passager;




        public TypePlace TypePlacePassager { get; set; }

        public Passager Passager
        {
            get => passager;
            set => passager = value;
        }
        
        public AvionPassager(Passager passager, TypePlace typePlacePassager)
        {
            this.passager = passager;
            TypePlacePassager = typePlacePassager;
        }
    }
}
