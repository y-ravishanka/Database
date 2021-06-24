using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace libraryms
{

    class SQLClass
    {
        private int i, j;
        Message msg = new Message();

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-R8SRBBL;Initial Catalog=LIBRARY;Integrated Security=True");

        public int insert_Staff(string id,string fname,string mname,string lname,string ads1, string ads2, string ads3, string uname,string pword,string gender,string mlname,string mid,int tele,string posi)
        {
            int tmp = 0;
            SqlCommand cmd = new SqlCommand(
                "insert into STAFF(staffid,fname,mname,lname,sadline1,sadline2,sadline3,username,password,gender,mlname,managerid,telephone,position) values (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n)"
                , con);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@a",id);
            cmd.Parameters.AddWithValue("@b",fname);
            cmd.Parameters.AddWithValue("@c",mname);
            cmd.Parameters.AddWithValue("@d",lname);
            cmd.Parameters.AddWithValue("@e",ads1);
            cmd.Parameters.AddWithValue("@f",ads2);
            cmd.Parameters.AddWithValue("@g",ads3);
            cmd.Parameters.AddWithValue("@h",uname);
            cmd.Parameters.AddWithValue("@i",pword);
            cmd.Parameters.AddWithValue("@j",gender);
            cmd.Parameters.AddWithValue("@k",mlname);
            cmd.Parameters.AddWithValue("@l",mid);
            cmd.Parameters.AddWithValue("@m",tele);
            cmd.Parameters.AddWithValue("@n",posi);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int update_Staff(string id,string field,string value)
        {
            int tmp = 0;
            string que = "update staff set " + field + " = '" + value + "' where staffid = '" + id + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }
        public int delete_Staff(string id)
        {
            int tmp = 0;
            string que = "update STAFF set status = 'Deactive' where staffid = '"+id+"'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }
        
        public int insert_Borrower(string borrowerid,string fname,string mname,string lname,string nic,
            string dob,string al1,string al2,string al3,string gender,string mlname,int[] tele,int index)
        {
            int tmp = 0;
            i = 0;
            string que = "INSERT INTO BORROWER VALUES ('" + borrowerid + "','" + fname + "','" + mname + "','" + lname +
                "','" + nic + "','" + dob + "','" + al1 + "','" + al2 + "','" + al3 + "','" + gender + "','" + mlname + "')";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
                while (i < index)
                {
                    string que1 = "Insert into borrowerTELEPHONE values (" + tele[i] + ",'" + borrowerid + "')";
                    SqlCommand cmd1 = new SqlCommand(que1, con);
                    cmd1.ExecuteNonQuery();
                    ++i;
                }
                i = 0;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int update_Borrower(string field,string value,string id)
        {
            int tmp = 0;
            string que = "UPDATE BORROWER SET " +field+ " = '" +value+ "' WHERE BorrowerID = '" +id+ "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_Borrower(string id)
        {
            int tmp = 0;
            string que = "DELETE FROM BorrowerTELEPHONE WHERE BorrowerID = '" + id+ "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int update_BorrowerTelephone(string bid,int tele)
        {
            int tmp = 0;
            string que = "update BorrowerTELEPHONE set Telephone='" + tele + "' where BorrowerID='" + bid + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_ManageBorrower(string sid,string bid,string type)
        {
            int tmp = 0;
            string que1 = "INSERT INTO ManagesBORROWER values ('" + sid + "','" + bid + "','" + type + "',getdate())";
            SqlCommand cmd1 = new SqlCommand(que1, con);
            try
            {
                con.Open();
                cmd1.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }
        
        public int delete_ManageBorrower(string id)
        {
            int tmp = 0;
            string que = "DELETE FROM ManagesBORROWER WHERE BorrowerID = '"+id+"'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_MLibrary(string mlname,string add1,string add2,string add3,int tel)
        {
            int tmp = 0;
            string que= "insert into MAINLIBRARY values('" + mlname + "','" + add1 + "','" + add2 + "','"
                + add3 + "'," + tel + ")";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }
        
        public int update_MLibrary(string field,string value,string mlname)
        {
            int tmp = 0;
            string que = "update MAINLIBRARY set " + field + " = '" + value + "' WHERE MLName = '" + mlname + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_MLibrary(string mlname)
        {
            int tmp = 0;
            string que = "DELETE FROM MAINLIBRARY WHERE MLName = '" + mlname + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_BLibrary(string blname,string add1,string add2,string add3,int tel,string mlname)
        {
            int tmp = 0;
            string que = "insert into BRANCHLIBRARY values('" + blname + "','" + add1 + "','" + add2 + "','" + add3 + "'," + tel + ",'" + mlname + "')";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch(Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int update_BLibrary(string field,string value,string blname)
        {
            int tmp = 0;
            string que = "update BRANCHLIBRARY  set " + field + " = '" + value + "' WHERE BLName  = '" + blname + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_BLibrary(string blname)
        {
            int tmp = 0;
            string que = "DELETE FROM BRANCHLIBRARY WHERE BLName = '" + blname + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_Book(string isbn,string title,string publish,string gen)
        {
            int tmp = 0;
            string que = "insert into BOOK values('" + isbn + "','" + title + "','" + publish + "','" + gen + "')";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int update_Book(string field,string value,string isbn)
        {
            int tmp = 0;
            string que = "update BOOK set " + field + " = '" + value + "' WHERE ISBN = '" + isbn + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_Book(string isbn)
        {
            int tmp = 0;
            string que = "DELETE FROM AUTHOR WHERE ISBN = '" + isbn + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_Copy(string id,double price,string library,string isbn)
        {
            int tmp = 0;
            string que = "insert into COPY values('" + id + "','" + price + "','" + library + "'," + isbn + ")";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int update_Copy(string field,string value,string id)    //  remove price update from interface
        {
            int tmp = 0;
            string que = "update COPY set " + field + " = '" + value + "' WHERE CopyID = '" + id + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_Copy(string id)
        {
            int tmp = 0;
            string que = "DELETE FROM COPY WHERE CopyID = '" + id + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_ManageCopy(string id,string cid,string type)     // how to insert data into this
        {
            int tmp = 0;
            string que = "insert into managesCOPY values ('"+id+"','"+cid+"','"+type+"',getdate())";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_OrverDue(string oid,string bid,string cid,string duedate)
        {
            int tmp = 0;
            string que = "insert into OVERDUE(borrowerid,copyid,duedate) values('" + bid + "','" + cid + "','" + duedate + "')" ;
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                string que1 = "insert into managesOverdue values('" + oid + "',(select top 1 overdueid from overdue where copyid = '"+cid+"' and borrowerid = '"+bid+"' and duedate = '"+duedate+"'))";
                SqlCommand cmd1 = new SqlCommand(que1,con);
                cmd1.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int update_OrverDue(string field,string value,string oid)
        {
            int tmp = 0;
            string que = "update OVERDUE set " + field + " = '" + value + "' WHERE OverdueID = '" + oid + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_OrverDue(string oid)
        {
            int tmp = 0;
            string que = "DELETE FROM OVERDUE WHERE OverdueID = '" + oid + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_ManageOrverDue(string oid)
        {
            int tmp = 0;
            string que = "DELETE FROM ManagesOVERDUE WHERE OverdueID = '" + oid + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_Loan(string borrowerdate,string borrowerid,string copyid,string staffid)
        {
            int tmp = 0;
            string que = "insert into Loans values('" + borrowerdate + "','" + staffid + "','" + borrowerid + "','" + copyid + "')"; 
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int delete_Loan(string cid,string bid,string sid)
        {
            int tmp = 0;
            string que ="delete from Loans where StaffID = '"+sid+"' and BorrowerID = '"+bid+"' and CopyID = '"+cid+"'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_Author(string[] author,string isbn,int index)
        {
            int tmp = 0;
            i = 0;
            try
            {
                con.Open();
                while (i < index)
                {
                    string que = "insert into AUTHOR values('" + author[i] + "','" + isbn + "')";
                    SqlCommand cmd = new SqlCommand(que, con);
                    cmd.ExecuteNonQuery();
                    ++i;
                }
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            i = 0;
            return tmp;
        }

        public int insert_Return(string returndate,string bid,string copyid)
        {
            int tmp = 0;
            string que = "insert into RETURNS values('" + returndate + "','" + bid + "','" + copyid + "')";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }
        
        public int delete_Return(string bid,string cid)
        {
            int tmp = 0;
            string que = "delete from RETURNS where CopyID = '"+cid+"' and BorrowerID = '"+bid+"'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_LoginTime(string staffid)
        {
            int tmp = 0;
            string que = "exec InsertLoginTime @staffid = '"+staffid+"'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public int insert_LogoutTime(string staffid)
        {
            int tmp = 0;
            string que = "exec InsertLogoutTime @staffid = '" + staffid + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                tmp = 1;
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public string[] check_login(string uname,string pword)
        {
            string[] tmp = new string[2];
            tmp[1] = null;
            int t = 0;
            string s1 = null;
            string que ="select password from staff where username ='"+uname+"'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    s1 = dr[0].ToString();
                }
                if (s1 == pword)
                {
                    t = 1;
                    dr.Close();
                    tmp[1] = get_staffID(uname);
                    if (tmp[1] == null)
                    {
                        t = 0;
                    }
                }
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                t = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            tmp[0] = t.ToString();
            return tmp;
        }

        public string get_staffID(string uname) // special TO REMEMBER
        {
            string tmp = null;
            string que ="select staffid from staff where username = '"+uname+"'";
            SqlCommand cmd1 = new SqlCommand(que, con);
            try
            {
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        tmp = dr1.GetString(0);
                    }
                }
                dr1.Close();
            }
            catch (Exception e)
            {
                tmp = null;
                string s = Convert.ToString(e); msg.invalid_data(s);
            }
            return tmp;
        }

        public int check_manager(string sid)
        {
            int tmp = 0;
            string s1 = null;
            string que = "select managerid from staff where staffid='" + sid + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    s1 = dr[0].ToString();
                }
                if (s1.Equals("")==true)
                {
                    tmp = 1;
                }
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = 0; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }

        public string get_MLname(string sid)
        {
            string tmp = null;
            string que = "select mlname from staff where staffid ='" + sid + "'";
            SqlCommand cmd = new SqlCommand(que, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tmp = dr[0].ToString();
                }
            }
            catch (Exception e)
            {
                string s = Convert.ToString(e);
                tmp = null; msg.invalid_data(s);
            }
            finally
            {
                con.Close();
            }
            return tmp;
        }
    }
}

/*
    public int ex()
    {
        int tmp = 0;
        string que =;
        SqlCommand cmd= new SqlCommand(que, con);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            tmp = 1;
        }
        catch(Exception e)
        {
            string s = Convert.ToString(e);
            tmp = 0; msg.invalid_data(s);
        }
        finally
        {
            con.Close();
        }
        return tmp;
    }
*/

/* 
 * SqlDataReader dr1 = cmd1.ExecuteReader();
    if (dr1.Read())
    {
        tmp1 = dr1[0].ToString();
    }
*/