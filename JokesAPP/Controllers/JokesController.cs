using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using JokesAPP.Dto;
using JokesAPP.Services;
using JokesAPP.Request;
using JokesAPP.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JokesAPP.Controllers
{
    public class JokesController : Controller
    {
        public readonly IMapper _mapper;
        public JokesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("/jokes")]
        [HttpGet]
        public IActionResult Index()
        {

            return View("./Index");
        }

        [Route("/jokeslist")]
        [HttpGet]
        public List<JokesDto> GetList()
        {
            List<JokesDto> JokesDtoList = new List<JokesDto>();
            JokesService jokesService = new JokesService();
            JokesDtoList = _mapper.Map<List<JokesDto>>(jokesService.GetList());
            return JokesDtoList;
        }
        [Route("lookup/{id}")]
        [HttpGet]
        public JokesDto GetById(int id)
        {
            JokesDto JokesDto = new JokesDto();
            JokesService jokesService = new JokesService();
            JokesDto = _mapper.Map<JokesDto>(jokesService.GetById(id));
            return JokesDto;
        }
        [Route("/seachfilter")]
        [HttpGet]
        public List<JokesDto> GetList(JokesDto SearchFilter)
        {
            var searchList = new List<JokesDto>();
            var req = _mapper.Map<JokesRequest>(SearchFilter);
            JokesService jokeservice = new JokesService();
            searchList = _mapper.Map<List<JokesDto>>(jokeservice.SearchList(req));
            return searchList;
        }


        [Route("/jokeupdate")]
        [HttpPost]
        public int Update(JokesModel jokeModel)
        {
            JokesService jokesService = new JokesService();
            int updated = jokesService.Update(jokeModel);
            return updated;
        }


        [Route("/jokecreate")]
        [HttpPost]
        public int Create(JokesModel newJoke)
        {
            JokesService loginservice = new JokesService();
            JokesModel jokeModel = new JokesModel
            {
                JokesQuestion = newJoke.JokesQuestion,
                JokesAnswer = newJoke.JokesAnswer,
                CreatedAt = DateTime.Now
            };
            int created = loginservice.Create(jokeModel);
            return created;
        }

        [Route("/jokedelete")]
        [HttpPost]
        public int Delete(JokesModel jokeModel)
        {
            int id = jokeModel.JokesID;
            JokesService jokeService = new JokesService();
            int deleted = jokeService.Delete(id);
            return deleted;
        }

        [Route("/signout")]
        [HttpPost]
        public void Signout(JokesModel jokeModel)
        {
            int id = jokeModel.JokesID;
            JokesService jokeService = new JokesService();
            jokeService.Delete(id);
        }
    }

}
