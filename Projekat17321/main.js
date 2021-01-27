import {Parkinzi} from "./Parkinzi.js"
fetch("https://localhost:5001/Parkinzi/PreuzmiViseParkinga").then(p=>{
    p.json().then(data=>{
       data.forEach(element => {
           const p1 = new Parkinzi(element.id,element.naziv,element.num,element.n,element.m);
           p1.crtajPark(document.body);
           var br=0;
           element.parkings.forEach(par=>
            {
              //p1.povrsine[br].azurirajparking(par.naselje,par.n,par.m,par.tip,par.brojzauzetih);
              var povrsina=p1.povrsine[br];
              par.listamesta.forEach(mes=>{
                  var mesto=povrsina.mesta[mes.x*povrsina.n+mes.y];
                  if(mesto.slobodno())
                     p1.povrsine[br].azurirajMesto(mes.x,mes.y,mes.tablica,mes.dani,mes.tip,mes.povsina,mes.naselje);
                    })
              p1.povrsine[br].azurirajparking(par.naselje,par.n,par.m,par.tip,par.brojzauzetih);
              br++;
            });
       });
    });
});

//const p1 = new Parkinzi("Grad Nis",3,4,6);
//p1.crtajPark(document.body);
//const p2 = new Parkinzi("Grad Nis",5,5,6);
//p2.crtajPark(document.body);
