﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnnection
    {
        private const string PrizesFile = "PrizeModels.csv";

        public PersonModel CreatePerson(PersonModel model)
        {
            throw new NotImplementedException();
        }

        //TODO - Wire up the CreatePrize for text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load the text file and Convert the text to List <PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            //Find the max ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            //Add the new record with the new ID (max + 1)
            prizes.Add(model);

            //convert the prizes to list<string>
            // save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
