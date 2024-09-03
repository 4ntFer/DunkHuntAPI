﻿using DuckHuntAPI.ClassObjects;
using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using DuckHuntAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.Controllers
{
    [ApiController]
    [Route("Animation")]
    public class AnimationController : Controller
    {

        [HttpGet]
        public ActionResult Get() {
            AnimationRepository AnimationRepos = new AnimationRepository(NHibernateHelper.GetSession(HttpContext));
            ImageSeqRepository ImgSeqRepos =  new ImageSeqRepository(NHibernateHelper.GetSession(HttpContext));
            ImageRepository ImgRepos = new ImageRepository(NHibernateHelper.GetSession(HttpContext));
            CharacterRepository characterRepository = new CharacterRepository(NHibernateHelper.GetSession(HttpContext));


            AnimationObjectFactory Factory = new AnimationObjectFactory(ImgSeqRepos, ImgRepos);
            List<Animation> animationsBDList = AnimationRepos.findAll();
            List<Dictionary<string, object>> animationsReturned;

            if (animationsBDList.Count != 0)
            {
                animationsReturned = new List<Dictionary<string, object>>();
                foreach (Animation abd in animationsBDList)
                {   
                    AnimationObject aobj = new AnimationObject(abd, Factory);
                    Dictionary<string, object> ar = new Dictionary<string, object>();
                    List<string> imgUrlList = new List<string>();

                    ar["Name"] = abd.Name;
                    ar["CharacterName"] = characterRepository.FindById(abd.CharacterId).name;
                    ar["Images"] = imgUrlList;

                    foreach (ImageObject imgobj in aobj.GetImages()) {
                        imgUrlList.Add(imgobj.url);
                    }

                    animationsReturned.Add(ar);
                }
                return Ok(animationsReturned);
            }

            return null;
        }
    }
}
