using CodeProjectWebApi.DTO;
using EdgeJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeProjectWebApi.Controllers
{
    public class MoviesController : ApiController
    {
        
        public async Task<Object> Get()
        {

            /* Example - Creating node.js http server per request just for fun  =)
                     var createHttpServer = Edge.Func(@"
                                                          var http = require('http');

                                                          return function (port, cb) {
                                                              http.createServer(function (req, res) {
                                                                  res.end('Hello, world! ' + new Date());
                                                              }).listen(port, cb);
                                                          };
                                                     ");

                     await createHttpServer(8080);
             */

            /* Example - Initiating an async request to another domain using Node.js  =) */
            var func = Edge.Func(@"
                                        var request = require('request');

                                        return function (url, callback) {
                                            request(url, function (error, response, body) {
                                                    if (!error && response.statusCode == 200) {
                                                        callback(null,[{'Id':1,'Name':'Fight Club','Director':'David Fincher'},{'Id':2,'Name':'Into The Wild','Director':'Sean Penn'},{'Id':3,'Name':'Dancer in the Dark','Director':'Lars von Trier'},{'Id':4,'Name':'WebAPI','Director':'Cool!'}]);
                                                    }else {
                                                        callback(error);
                                                    }
                                            });

                                        };
                                    ");

            dynamic result;

            try
            {
                result = await func("http://www.casadotambemnamora.com.br");

                if (null == result)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "The service is unreachable!"));
                }

            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "The service is unreachable!"));
            }
            

            return result as object;

        }

    }
}