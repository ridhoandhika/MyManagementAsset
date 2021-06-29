using MyManagementAsset.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyManagementAsset.Context
{
    public class ItemJenis_DAL
    {
        readonly string connectionString = "Data Source = LAPTOP-UDUKJKGR\\IT; Initial Catalog=MyManagementAsset; Integrated Security=SSPI; User ID = sa; Password=123456;";

        public static List<ItemJenis> ItemJenisList { get; set; }
        public IEnumerable<ItemJenis> GetAllItemJenis()
        {
            var ItemJenisList = new List<ItemJenis>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllItemJenis", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var itemjenis = new ItemJenis();
                    itemjenis.jns_kode = dr["jns_kode"].ToString();
                    itemjenis.jns_description = dr["jns_description"].ToString();
                    itemjenis.jns_initial = dr["jns_initial"].ToString();

                    ItemJenisList.Add(itemjenis);

                }
                con.Close();
            }
            return ItemJenisList;
        }
        public void CreateItemJenis(ItemJenis itemjenis)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CreateItemJenis", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Desc", itemjenis.jns_description);
                cmd.Parameters.AddWithValue("@initial", itemjenis.jns_initial);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateItemJenis(ItemJenis itemjenis)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateItemJenis", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@jns_kode", itemjenis.jns_kode);
                cmd.Parameters.AddWithValue("@Desc", itemjenis.jns_description);
                cmd.Parameters.AddWithValue("@initial", itemjenis.jns_initial);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteItemJenis(ItemJenis itemjenis)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteItemJenis", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@jns_kode", itemjenis.jns_kode);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ItemJenis GetItemJenisById(string? jns_kode)
        {
            var itemjenis = new ItemJenis();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetItemJenisByKode", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@jns_kode", jns_kode);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    itemjenis.jns_kode = dr["jns_kode"].ToString();
                    itemjenis.jns_description = dr["jns_description"].ToString();
                    itemjenis.jns_initial = dr["jns_initial"].ToString();
                   
                }
                con.Close();
            }
            return itemjenis;
        }
    }
}
