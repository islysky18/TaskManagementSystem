using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagementDAL;

namespace TaskManagementSystem.Controllers
{
    public class QuoteController : ApiController
    {
        // GET: api/Quote
        public IEnumerable<Quote> Get()
        {
            using (Entities entities = new Entities()) {
                return entities.Quotes.ToList();
            }
                //return new string[] { "value1", "value2" };
        }

        // GET: api/Quote/5
        public HttpResponseMessage Get(int id)
        {
            using (Entities entities = new Entities()) {
                var entity = entities.Quotes.FirstOrDefault(q => q.QuoteID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Quote Id = " + id.ToString() + " not found");
                }

            }
        }

        // POST: api/Quote
        public HttpResponseMessage Post([FromBody]Quote quote)
        {
            try {
                using (Entities entities = new Entities()) {
                    entities.Quotes.Add(quote);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, quote);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + quote.QuoteID.ToString());
                    return message;
                }
            
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        // PUT: api/Quote/5
        public HttpResponseMessage Put(int id, [FromBody] Quote quote)
        {
            try
            {
                using (Entities entities = new Entities())
                {
                    var entity = entities.Quotes.FirstOrDefault(q => q.QuoteID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Quote with Id = " + id.ToString() + " is not found");
                    }
                    else
                    {
                        entity.QuoteType = quote.QuoteType;
                        entity.Contact = quote.Contact;
                        entity.Task = quote.Task;
                        entity.DueDate = quote.DueDate;
                        entity.TaskType = quote.TaskType;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }

                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

        }
        // DELETE: api/Quote/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (Entities entities = new Entities())
                {

                    var entity = entities.Quotes.FirstOrDefault(e => e.QuoteID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Quote with Id = " + id.ToString() + " is not found");
                    }
                    else
                    {
                        entities.Quotes.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
 }
