using Carriers.Data.Contract;
using Carriers.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Carriers.Web.Controllers.WebApi
{
    public class CarriersApiController : BaseApiController
    {
        public CarriersApiController(IUow uow)
        {
            Uow = uow;
        }

        // GET: api/carriers
        [HttpGet]
        [Route("api/carriers")]
        public async Task<List<Carrier>> Get()
        {
            var carriers = await Uow.Carriers.GetAllAsync();
            return carriers;
        }

        // GET: api/carriers/1
        [HttpGet]
        [Route("api/carriers/{id}")]
        public async Task<Carrier> Get(int id)
        {
            var carrier = await Uow.Carriers.FindAsync(s=>s.Id == id);
            return carrier;
        }
        
        [System.Web.Http.HttpPost]
        [Route("api/postCarrier/{name}/{description}")]
        public async Task<HttpResponseMessage> PostCarrier(string name, string description)
        {
            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                
                var carrier = new Carrier();
                carrier.Name = name;
                carrier.Description = description;
                carrier.DateCreated = DateTime.Now;
                await Uow.Carriers.AddAsync(carrier);
                Uow.Commit();

                var response = Request.CreateResponse(HttpStatusCode.Created, carrier);
                return response;
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Http.HttpPut]
        [Route("api/putCarrier/{id}/{name}/{description}")]
        public async Task<HttpResponseMessage> PutCarrier(int id, string name, string description)
        {
            try
            {
                if (id == 0 || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);


                var carrier = await Uow.Carriers.FindAsync(s=>s.Id == id);
                if (carrier == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

                carrier.Name = name;
                carrier.Description = description;

                await Uow.Carriers.UpdateAsync(carrier);
                Uow.Commit();

                var response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Http.HttpPut]
        [Route("api/deleteCarrier/{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCarrier(int id)
        {
            Carrier carrier = await Uow.Carriers.FindAsync(p => p.Id == id);
            if (carrier == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var ratings = await Uow.Ratings.FindAllAsync(s => s.CarrierId == id);
            if (ratings != null && ratings.Count > 0)
            {
                foreach(var rating in ratings)
                {
                    await Uow.Ratings.RemoveAsync(rating);

                    try
                    {
                        Uow.Commit();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        return Request.
                            CreateErrorResponse(HttpStatusCode.BadGateway, ex);
                    }

                }
            }

            await Uow.Carriers.RemoveAsync(await Uow.Carriers.FindAsync(p => p.Id == id));

            try
            {
                Uow.Commit();
                //return new HttpResponseMessage(HttpStatusCode.NoContent);
                return Request.CreateResponse(HttpStatusCode.OK, carrier);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

        }

        // GET: api/carriers/1/ratings
        [HttpGet]
        [Route("api/carriers/{carrierId}/ratings")]
        public async Task<List<Rating>> GetRatings(int carrierId)
        {
            var ratings = await Uow.Ratings.FindAllAsync(s => s.CarrierId == carrierId);
            return ratings;
        }

        [System.Web.Http.HttpPost]
        [Route("api/postRating/{carrierId}/{ratingValue}/{comment}/{userId}/{userName}")]
        public async Task<HttpResponseMessage> PostRagting(int carrierId, int ratingValue, string comment, string userId, string userName)
        {
            try
            {
                Carrier carrier = await Uow.Carriers.FindAsync(p => p.Id == carrierId);
                if (carrier == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (ratingValue == 0 || string.IsNullOrEmpty(comment) || string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userName))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);


                var rating = new Rating();
                rating.CarrierId = carrierId;
                rating.RatingValue = ratingValue;
                rating.Comment = comment;
                rating.UserId = userId;
                rating.UserName = userName;
                await Uow.Ratings.AddAsync(rating);
                Uow.Commit();

                var response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}