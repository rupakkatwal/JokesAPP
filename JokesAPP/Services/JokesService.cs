using System;
using System.Collections.Generic;
using JokesAPP.DAO;
using JokesAPP.Models;
using JokesAPP.Request;

namespace JokesAPP.Services
{
    public class JokesService
    {
        public List<JokesModel> GetList()
        {
            JokesDAO JokesDAO = new JokesDAO();

            var jokeslist  = JokesDAO.fetchall();
            return jokeslist;
        }
        public int Create(JokesModel JokesModel)
        {
            JokesDAO JokesDAO = new JokesDAO();

            int created = JokesDAO.Create(JokesModel);
            return created;
        }
        public int Update(JokesModel JokesModel)
        {
            JokesDAO JokesDAO = new JokesDAO();

            int updated = JokesDAO.update(JokesModel);
            return updated;
        }

        public void Signout(int id)
        {
            JokesDAO JokesDAO = new JokesDAO();

            JokesDAO.Signout(id);
        }

        public int Delete(int id)
        {
            JokesDAO JokesDAO = new JokesDAO();

            int deleted = JokesDAO.Delete(id);
            return deleted;
        }
        public JokesModel GetById(int id)
        {
            JokesDAO JokesDAO = new JokesDAO();

            var jokes = JokesDAO.GetById(id);
            return jokes;
        }
        public List<JokesModel> SearchList(JokesRequest req)
        {
            
            JokesDAO JokesDAO = new JokesDAO();
            DateTime currentDateTime = DateTime.Now;
            if (req.JokesPosted ==  1)
            {
                req.CreatedAt = currentDateTime.AddHours(24);

            }
           else if(req.JokesPosted == 2)
            {
                req.CreatedAt = currentDateTime.AddDays(7);
            }
           else if(req.JokesPosted == 3)
            {
                req.CreatedAt = currentDateTime.AddDays(30);
            }

            var reqList = new List<JokesModel>();
            reqList = JokesDAO.SearchList(req);

            return reqList;
        }
    }
}

