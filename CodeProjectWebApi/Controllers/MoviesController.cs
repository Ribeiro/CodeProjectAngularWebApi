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

        public async Task<IEnumerable<MoviesDTO>> Get()
        {
            // this list should be fetched from the DB
            // you can use Entity Framework (EF)
            // for best practice, do not use EF inside the controller.
            // Instead use EF inside a class that implements an interface

            List<MoviesDTO> movies = new List<MoviesDTO>
        {
            new MoviesDTO { Id = 1, Name = "Fight Club", Director = "David Fincher" },
            new MoviesDTO { Id = 2, Name = "Into The Wild", Director = "Sean Penn" },
            new MoviesDTO { Id = 3, Name = "Dancer in the Dark", Director = "Lars von Trier" },
            new MoviesDTO { Id = 4, Name = "WebAPI", Director = "Cool!" }
        };

            try
            {

                /*var createHttpServer = Edge.Func(@"
        var http = require('http');

        return function (port, cb) {
            http.createServer(function (req, res) {
                res.end('Hello, world! ' + new Date());
            }).listen(port, cb);
        };
    ");

                await createHttpServer(8080);*/

                var func = Edge.Func(@"
                                        var request = require('request');

                                        return function (url, cb) {
                                            request(url, function (error, response, body) {
                                                    if (!error && response.statusCode == 200) {
                                                        cb(body);
                                                    }else {
                                                        cb(error);
                                                    }
                                            });

                                        };
                                    ");

                var result = await func("http://www.modulus.io");

                var test = "";


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            

            return movies;
        }

    }
}
