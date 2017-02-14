using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;

namespace redcap_det.Controllers
{
    [Route("api/[controller]")]
    public class TriggerController: Controller
    {
        // POST api/trigger
        // redcap det settings: http://localhost:80/api/trigger
        [HttpPost]
        public IActionResult Post()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string record = "";
                    var form = Request.ReadFormAsync();
                    var formData = form.Result;
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    ///List<string> trigger = new List<string>();
                    foreach (var key in formData.Keys)
                    {
                        /// extract value
                        var value = formData[key.ToString()];
                        /// add to the dictionary
                        data.Add(key, value);
                    }
                    if (data.ContainsKey("record"))
                    {
                        record = data["record"];

                    }
                    // Log this to the debug window
                    Log.Information("Record Found: " + record);

                    /// Make your decisions
                    /// Save to db?
                    /// Email to users? 
                    /// Pull the record that was provided for this project into db?
                    /// Send data somewhere?
                    return Ok(record);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return BadRequest(ex);
                }
            }
            return BadRequest();

        }

    }
}
