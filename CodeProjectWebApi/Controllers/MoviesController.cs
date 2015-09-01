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
            // this list should be fetched from the DB
            // you can use Entity Framework (EF)
            // for best practice, do not use EF inside the controller.
            // Instead use EF inside a class that implements an interface

            /*var createHttpServer = Edge.Func(@"
      var http = require('http');

      return function (port, cb) {
          http.createServer(function (req, res) {
              res.end('Hello, world! ' + new Date());
          }).listen(port, cb);
      };
  ");

              await createHttpServer(8080);*/
                          
            //try
            //{

              

                /*var func = Edge.Func(@"
                                        var request = require('request');

                                        return function (url, cb) {
                                            request(url, function (error, response, body) {
                                                    if (!error && response.statusCode == 200) {
                                                        cb([{'Id':1,'Name':'Fight Club','Director':'David Fincher'},{'Id':2,'Name':'Into The Wild','Director':'Sean Penn'},{'Id':3,'Name':'Dancer in the Dark','Director':'Lars von Trier'},{'Id':4,'Name':'WebAPI','Director':'Cool!'}]);
                                                    }else {
                                                        cb(error);
                                                    }
                                            });

                                        };
                                    ");*/

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

            var result = await func("http://www.modulus.io");

            return result as object;


            //}
            //catch (Exception e)
            //{
            //Console.WriteLine(e.Message);
            //}

            //return movies;


        }

    }
}
