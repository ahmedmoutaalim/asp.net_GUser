using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace crudApp.Models
{
    public class EtudiantDal
    {

        string cnx = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EtudiantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // to get all 
        public IEnumerable<EtudiantInfo> GetAllEtudiant() {


            List<EtudiantInfo> etdList = new List<EtudiantInfo>();

            using (SqlConnection con = new SqlConnection(cnx)) {

                SqlCommand cmd = new SqlCommand("SP_GetEudiant", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

               // Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
                while (dr.Read())
                {
                    EtudiantInfo etd = new EtudiantInfo();
                    etd.ID = Convert.ToInt32(dr["ID"].ToString());
                    etd.Nom = dr["Nom"].ToString();
                    etd.Prenom = dr["Prenom"].ToString();
                    etd.Cin = dr["Cin"].ToString();
                    etd.Adress = dr["Adress"].ToString();

                    etdList.Add(etd);

                }

                con.Close();

            }


            return etdList;
        }

        // Insert etd

        public void AddEtudiant(EtudiantInfo etd)
        {
            using (SqlConnection con = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEtudiant", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nom", etd.Nom);
                cmd.Parameters.AddWithValue("@Prenom", etd.Prenom);
                cmd.Parameters.AddWithValue("@Cin", etd.Cin);
                cmd.Parameters.AddWithValue("@Adress", etd.Adress);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        // update etudiant

        public void UpdateEtudiant(EtudiantInfo etd)
        {
            using (SqlConnection con = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEtudiant", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EtdID", etd.ID);
                cmd.Parameters.AddWithValue("@Nom", etd.Nom);
                cmd.Parameters.AddWithValue("@Prenom", etd.Prenom);
                cmd.Parameters.AddWithValue("@Cin", etd.Cin);
                cmd.Parameters.AddWithValue("@Adress", etd.Adress);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // delete Etudiant

        public void deleteEtudiant(int? etdId)
        {
            using(SqlConnection con = new SqlConnection(cnx))
            {
               
                SqlCommand cmd = new SqlCommand("SP_DeleteEtudiant", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EtdID", etdId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }
        }

        // select etudiant by id 

        public EtudiantInfo GetEtudiantById(int? etdId)
        {


            EtudiantInfo etd = new EtudiantInfo();

            using (SqlConnection con = new SqlConnection(cnx))
            {

                SqlCommand cmd = new SqlCommand("SP_GetEtudiantByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EtdID", etdId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    etd.ID = Convert.ToInt32(dr["ID"].ToString());
                    etd.Nom = dr["Nom"].ToString();
                    etd.Prenom = dr["Prenom"].ToString();
                    etd.Cin = dr["Cin"].ToString();
                    etd.Adress = dr["Adress"].ToString();

                 

                }

                con.Close();

            }


            return etd;
        }
    }
}
