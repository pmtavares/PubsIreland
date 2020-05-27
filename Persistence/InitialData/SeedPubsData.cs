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
                        ImagePath = "assets/images/pubs/j-w-sweetman.jpg",
                        DescriptionDetailed = "Our site here at 1&2 Burgh Quay dates back as far as 1808 with a lot of history and stories to tell. Housed inside this wonderful 19Th century building is a microbrewery, a pub and a restaurant. We at J.W. Sweetmans would like to welcome you to be a part of something special. Number 1 Burgh Quay began as a tavern which offered welcome hospitality to the ships that were docked outside its door. Meanwhile, next door at 2 Burgh Quay, flax, rope and hemp was manufactured and sold. Later on, 2 Burgh Quay housed the Dublin Library Society. Meetings were held regularly in what we now know as the “Conversation Room”, accessible on our first floor and still parading its original ceiling roses.  Here we pay homage to our site’s rich history and encourage the appreciation of great Irish literature. There was a time when Ireland was renowned for its brewing excellence, with hundreds of breweries producing beers of every description.  The excise list for 1768 showed returns for forty three brewers in Dublin City, with many of these large operations employing dozens of workers. Dublin was home to a thriving and truly cosmopolitan brewing industry, with twelve breweries situated along the banks of the River Liffey by the end of the eighteen century. In 1756, our namesake, John William Sweetman, established his own extensive network of breweries in the capital. He was an esteemed politician, architect and art connoisseur. By the 1820’s, the Sweetman’s breweries were producing 450 barrels per week, and were bettered only by Guinness’ with 600 barrels per week. ",
                        Username = "jwsweet"

                    },
                    new Pub
                    {

                        Name= "OConnells Bar",
                        Description= "We are a traditional-style pub with tons of energy and a warm inviting atmosphere. O’Connell’s was once a grocery and small bar but has been solely a pub since the 1970’s. The décor is truly stunning with most of our original fixtures and fittings still intact. These include tiled floors, antique lighting, stained glass windows, solid wooden seating plus an amazing pressed tin ornate ceiling in our front bar.",
                        Address =  "1-2 Burgh Quay, Dublin 2, D02 F243",
                        CityId = 2,
                        PhoneNumber= "(091) 563 634",
                        Website =  "http://oconnellsbargalway.com/",
                        Username = "oconell",
                        
                    },
                    new Pub
                    {

                        Name=  "The Shelbourne Bar",
                        Description= "The Shelbourne Bar is a sophisticated Irish pub in Cork City with an authentic traditional atmosphere.Nestled in the heart of The Victorian Quarter of Cork City since 1895, it is renowned for its welcoming and knowledgeable staff, great service and extensive Irish whiskey offering of over 300 bottlings – the largest and best collection in Cork!",
                        Address = "17 MacCurtain Street, Centre, Cork, T23 DE79",
                        CityId = 3,
                        PhoneNumber= "(021) 450 9615",
                        Website = "https://www.theshelbournecork.ie/",
                        Username = "shell"
                    },
                    new Pub
                    {

                        Name=  "Flannerys Bar Limerick",
                        Description= "Michael Flannery’s Pub is well known to everyone in Limerick. Located on Denmark Street, alongside the pedestrian shopping area of Limerick and just around the corner from the famous Milk Market, its vibrant red shopfront is set off against a beautiful stone façade.",
                        Address = "17 Upper Denmark St, Limerick, V94 T9W3",
                        CityId = 4,
                        PhoneNumber= "(061) 436 677",
                        Website = "https://www.flannerysbar.ie/",
                        Username = "flanner"
                    },
                     new Pub
                    {

                        Name=  "The Celt",
                        Description="When you come to The Celt Bar you can expect a warm and friendly welcome and don’t forget to ask one of our servers for a pint of the Black Stuff to really feel like you’re at home. The Celt is located in the north side of Dublin and it’s as appealing to visitors to the area as it is to the locals. We’re the perfect Irish pub where you’ll find a tasty pub menu, ideal if you want something quick for lunch or if you’re after a main evening meal you won’t be disappointed",
                        Address = "81 Talbot St, North City, Dublin, D01 YK51",
                        CityId = 1,
                        PhoneNumber= "(01) 878 8655",
                        Website = "https://www.thecelt.ie/",
                        Username = "celt"

                    },
                     new Pub
                    {

                        Name= "The Temple Bar",
                        Description="A very sincere and heartfelt welcome to the authentic home of Irish Cultural heritage. Since 1840 this quintessential Dublin pub has dispensed renowned hospitality and traditions of excellence to generations of Dubliners and visitors alike. Today The Temple Bar is famous across the globe for its traditional ambience, unrivalled vitality and for our celebrated charm and conviviality.Additionally we have become the established home of traditional Irish music in Dublin, the pub with the largest selection of whiskies in Ireland and the pub with the largest selection of sandwiches in the world. But what we do best is ensuring that your visit to The Temple Bar is the best pub experience you will ever remember.",
                        Address = "47-48, Temple Bar, Dublin 2, D02 N725",
                        CityId = 1,
                        PhoneNumber= "(01) 672 5286",
                        Website = "https://www.thetemplebarpub.com/",
                        Username = "temple",
                        ImagePath = "assets/images/pubs/templebardublin.jpg",
                        DescriptionDetailed = "Our story goes as far back 1599 where Sir William Temple , a renowned teacher and philosopher, entered the service of the Lord Deputy of Ireland. In 1609, Temple was made Provost of Trinity College, Dublin and Master Chancery in Ireland and moved to this country. Sir William Temple built his house and gardens on newly reclaimed land here on the corner of Temple Lane and the street called Temple Bar. In 1656, his son, Sir John Temple, acquired additional land which, with reclamation made possible by the building of a new sea wall, allowed the development of the area we know as Temple Bar. In the 17th century “Barr” (later shortened to Bar) usually meant a raised estuary sandbank often used for walking on. Thus the river Liffey embankment alongside the Temple’s Barr or simply Temple Bar. Later this evolved into the present throughfare connecting this whole area from Westmoreland Street to Fishamble Street "
                    },
                     new Pub
                    {

                        Name= "An Pucan",
                        Description="An Púcán Galway is first and foremost, a genuine, great craic, proud to be Irish Bar. We are located on the corner of Eyre Square in the beating heart of Galway. With a fantastic chef, great bar staff and inside the beautiful surroundings of Galway’s city centre, An Púcán is a great place to eat or party, morning, noon and night.",
                        Address = "11 Forster St, Galway",
                        CityId = 2,
                        PhoneNumber= "(091) 376 561",
                        Website = "https://anpucan.ie/",
                        DescriptionDetailed="Our main focus is the customer and always trying to come up with new ideas to make the customers experience more enjoyable and we hope we are doing just that, so if you are ever in Galway please feel free to drop in and let us know how we are getting on! We take pride in looking after our beers, the Guinness is regularly touted by reviewers and customers alike as the best in Galway, the atmosphere is friendly and welcoming and we would put our bar staff up against the best of them. From the outside it looks very small, and yet as soon as you walk in you realise that it stretches a long way back. At the rear you’ll find our newly renovated beer garden, which for much of the year is a great sun-trap.",
                        Username = "pucan",
                        ImagePath = "assets/images/pubs/anpucan.jpg"
                    },
                     new Pub
                    {

                        Name= "The Brazen Head",
                        Description="The Brazen Head has a well-deserved reputation for great food, serving both traditional and contemporary dishes. Famed for our traditional stews of beef and guinness and Irish stew, these hearty dishes combine all the ingredients in one bowl.",
                        Address ="20 Bridge Street Lower, Dublin 8",
                        CityId = 2,
                        PhoneNumber= " 1 6795186",
                        Website = "http://www.brazenhead.com/",
                        ImagePath = "assets/images/pubs/the-brazen-head.jpg",
                        DescriptionDetailed = "The Brazen Head is Irelands oldest pub. In fact there has been a hostelry here since 1198. The present building was built in 1754 as a coaching inn.  However The Brazen Head appears in documents as far back as 1653.  An advertisement from the 1750’s reads “Christopher Quinn of The Brazen Head in Bridge Street has fitted said house with neat accommodations and commodious cellars for said business”. The Brazen Head is located on Bridge Street.  This is the area from where the original settlement that was to become Dublin got its name.  The Irish name for Dublin is Baile Atha Cliath – (pronounced: Ball-ya-Awha-Clia) which means “The Town of the Ford of the Reed Hurdles”.  Beside the pub is the Father Matthew Bridge crosses the river Liffey.  It was at this very spot that the original crossing of the river was located.  Here reed matting was positioned on the river bed which enabled travellers to cross safely at low tide.",
                        Username = "brazen"
                    },
                      new Pub
                    {

                        Name= "The Brass Fox",
                        Description="Winner of Best Newcomer Pub Award – East Region, In The Irish Pub Awards 2018. A charming, quirky, and Traditional Irish Pub in the heart of Wicklow Town famous for its delicious wings, friendly staff and charming interior décor! The Brass Fox is a beautiful sea-side pub where you can happily enjoy delicious, home-made food, Signature Cocktails, and Fine Spirits.",
                        Address ="14-15 Leitrim Pl, Wicklow, Ireland",
                        CityId = 6,
                        PhoneNumber= "0404 64432",
                        Website = "https://wicklow.thebrassfox.ie/",
                        ImagePath  ="assets/images/pubs/brassfox.jpg",
                        DescriptionDetailed = "Recently the winner in the Best Newcomer category in the 2018 Irish Pub Awards, The Brass Fox is not your ordinary old pub – " +
                        "this husband & wife run pub is a new, innovative and quirky spot in its appeal and design. Offering top class Gin Creations, Unrivalled Food Menu, and refined Cocktail List, it is definitely worth treading off the beaten track for! The modern interior combing old charms makes for a memorable visit as you journey from room to room and the food is outstanding. Enjoy a cosy meet-up in the Drawing room, a quiet session in the Meeting Room or the convivial and busy atmosphere of the Lounge area – it’s the perfect location for rowdy gangs, family gatherings, or corporate meetings!",
                        Username = "brass"

                    },
                        new Pub
                    {

                        Name= "The Bridge Tavern",
                        Description="Nestled in the heart of Wicklow Town, the Bridge Tavern is a unique location for leisure breaks, christenings, family get-togethers and more. We offer quality accommodation in Wicklow Town, delicious breakfast, lunch and dinner served everyday and a wide range of drinks available in our Riverside Lounge, Bar & Snug. ",
                        Address ="Bridge Street, Wicklow Town",
                        CityId = 6,
                        PhoneNumber= "0404 64760",
                        Website = "https://www.bridgetavern.ie/",
                        ImagePath  ="assets/images/pubs/tavern.jpg",
                        DescriptionDetailed = "Recently the winner in the Best Newcomer category in the 2018 Irish Pub Awards, The Brass Fox is not your ordinary old pub – " +
                        "this husband & wife run pub is a new, innovative and quirky spot in its appeal and design. Offering top class Gin Creations, Unrivalled Food Menu, and refined Cocktail List, it is definitely worth treading off the beaten track for! The modern interior combing old charms makes for a memorable visit as you journey from room to room and the food is outstanding. Enjoy a cosy meet-up in the Drawing room, a quiet session in the Meeting Room or the convivial and busy atmosphere of the Lounge area – it’s the perfect location for rowdy gangs, family gatherings, or corporate meetings!",
                        Username = "brass"

                    },


                };
                context.Pubs.AddRange(pubs);
            }
            context.SaveChanges();
        }
    }
}
