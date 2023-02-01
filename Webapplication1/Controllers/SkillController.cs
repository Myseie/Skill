using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using Webapplication1.Models;

namespace Webapplication1.Controllers
{
    public class SkillController : Controller
    {
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Webapplication1");
            var collection = database.GetCollection<Skill>("skilllibrary");
            List<Skill> skills = collection.Find(s => true).ToList();
            return View(skills);
        }
        public IActionResult CreateSkill()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Webapplication1");
            var collection = database.GetCollection<Skill>("skilllibrary");
            collection.InsertOne(skill);

            return Redirect("/Home/");
        }

        public IActionResult ShowSkills()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Webapplication1");
            var collection = database.GetCollection<Skill>("skilllibrary");
            List<Skill> skills = collection.Find(s => true).ToList();

            return View(skills);
        }

        public IActionResult ShowSkill(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Webapplication1");
            var collection = database.GetCollection<Skill>("skilllibrary");
           
            Skill skills = collection.Find(s=>s.Id == objectId).FirstOrDefault();
            return View(skills);
        }
        [HttpPost]
        public IActionResult DeleteSkill(string Id)
        {
            ObjectId skillId= new ObjectId(Id);
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Webapplication1");
            var collection = database.GetCollection<Skill>("skilllibrary");
            collection.DeleteOne(s=> s.Id == skillId);
            return Redirect("/Skill/");
        }

    }
}
