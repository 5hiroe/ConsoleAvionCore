using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAvion
{
	public class Passager
	{
	    #region Attributs
	    
	    private int id;
	    private string nom;
	    private DateTime dateNaissance;
	    private int pointFidelite;
	    
	    #endregion

	    #region Propriétés



	    public int Id
	    {
		    get => id;
		    set => id = value;
	    }

	    public string Nom
	    {
		    get => nom;
		    set => nom = value;
	    }

	    public DateTime DateNaissance
	    {
		    get => dateNaissance;
		    set => dateNaissance = value;
	    }

	    public int PointFidelite
	    {
		    get => pointFidelite;
		    set => pointFidelite = value;
	    }

	    public string Identite
	    {
		    get
		    {
			    return (Nom + ", né le " + DateNaissance.ToString("D") + " Dispose de " + PointFidelite + " Points fidélité");
		    }
	    }

	    #endregion

	    #region Constructeurs

	    public Passager(int id, string nom, DateTime dateNaissance)
	    {
		    this.id = id;
		    this.nom = nom;
		    this.dateNaissance = dateNaissance;
	    }

	    public Passager(int id, string nom, DateTime dateNaissance, int pointFidelite)
		    : this(id, nom, dateNaissance)
	    {
		    this.pointFidelite = pointFidelite;
	    }

	    #endregion
	}
}
