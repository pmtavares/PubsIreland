using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.InitialData
{
    public class SeedPubsData
    {
        public static void SeedData(DataContext context)
        {
            if(!context.Pubs.Any())
            {
                var pubs = new List<Pub>
                {
                    new Pub
                    {

                        Name= "JW Sweetman",
                        Description= "Our site here at 1&2 Burgh Quay dates back as far as 1808 with a lot of history and stories to tell. Housed inside this wonderful 19Th century building is a microbrewery, a pub and a restaurant. We at J.W. Sweetmans would like to welcome you to be a part of something special.",
                        Address =  "1-2 Burgh Quay, Dublin 2, D02 F243",
                        CityId = 1,
                        PhoneNumber= "(01) 670 5777",
                        Website =  "https://www.jwsweetman.ie/",
                        
                    },
                    new Pub
                    {

                        Name= "OConnells Bar",
                        Description= "We are a traditional-style pub with tons of energy and a warm inviting atmosphere. O’Connell’s was once a grocery and small bar but has been solely a pub since the 1970’s. The décor is truly stunning with most of our original fixtures and fittings still intact. These include tiled floors, antique lighting, stained glass windows, solid wooden seating plus an amazing pressed tin ornate ceiling in our front bar.",
                        Address =  "1-2 Burgh Quay, Dublin 2, D02 F243",
                        CityId = 2,
                        PhoneNumber= "(091) 563 634",
                        Website =  "http://oconnellsbargalway.com/"
                    },
                    new Pub
                    {

                        Name=  "The Shelbourne Bar",
                        Description= "The Shelbourne Bar is a sophisticated Irish pub in Cork City with an authentic traditional atmosphere.Nestled in the heart of The Victorian Quarter of Cork City since 1895, it is renowned for its welcoming and knowledgeable staff, great service and extensive Irish whiskey offering of over 300 bottlings – the largest and best collection in Cork!",
                        Address = "17 MacCurtain Street, Centre, Cork, T23 DE79",
                        CityId = 3,
                        PhoneNumber= "(021) 450 9615",
                        Website = "https://www.theshelbournecork.ie/"
                    },
                    new Pub
                    {

                        Name=  "Flannerys Bar Limerick",
                        Description= "Michael Flannery’s Pub is well known to everyone in Limerick. Located on Denmark Street, alongside the pedestrian shopping area of Limerick and just around the corner from the famous Milk Market, its vibrant red shopfront is set off against a beautiful stone façade.",
                        Address = "17 Upper Denmark St, Limerick, V94 T9W3",
                        CityId = 4,
                        PhoneNumber= "(061) 436 677",
                        Website = "https://www.flannerysbar.ie/"
                    },
                     new Pub
                    {

                        Name=  "The Celt",
                        Description="When you come to The Celt Bar you can expect a warm and friendly welcome and don’t forget to ask one of our servers for a pint of the Black Stuff to really feel like you’re at home. The Celt is located in the north side of Dublin and it’s as appealing to visitors to the area as it is to the locals. We’re the perfect Irish pub where you’ll find a tasty pub menu, ideal if you want something quick for lunch or if you’re after a main evening meal you won’t be disappointed",
                        Address = "81 Talbot St, North City, Dublin, D01 YK51",
                        CityId = 1,
                        PhoneNumber= "(01) 878 8655",
                        Website = "https://www.thecelt.ie/"
                    },
                     new Pub
                    {

                        Name= "The Temple Bar",
                        Description="A very sincere and heartfelt welcome to the authentic home of Irish Cultural heritage. Since 1840 this quintessential Dublin pub has dispensed renowned hospitality and traditions of excellence to generations of Dubliners and visitors alike. Today The Temple Bar is famous across the globe for its traditional ambience, unrivalled vitality and for our celebrated charm and conviviality.Additionally we have become the established home of traditional Irish music in Dublin, the pub with the largest selection of whiskies in Ireland and the pub with the largest selection of sandwiches in the world. But what we do best is ensuring that your visit to The Temple Bar is the best pub experience you will ever remember.",
                        Address = "47-48, Temple Bar, Dublin 2, D02 N725",
                        CityId = 1,
                        PhoneNumber= "(01) 672 5286",
                        Website = "https://www.thetemplebarpub.com/"
                    },
                     new Pub
                    {

                        Name= "An Pucan",
                        Description="An Púcán Galway is first and foremost, a genuine, great craic, proud to be Irish Bar. We are located on the corner of Eyre Square in the beating heart of Galway. With a fantastic chef, great bar staff and inside the beautiful surroundings of Galway’s city centre, An Púcán is a great place to eat or party, morning, noon and night.",
                        Address = "11 Forster St, Galway",
                        CityId = 2,
                        PhoneNumber= "(091) 376 561",
                        Website = "https://anpucan.ie/"
                    },

                };
                context.Pubs.AddRange(pubs);
            }
            context.SaveChanges();
        }
    }
}
