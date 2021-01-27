import {Mesta} from "./Mesta.js"
export class Parking{
    constructor(naselje,n,m,tip,brojzauzetih)
    {
        this.tip=tip;
        this.naselje=naselje;
        this.n=n;
        this.m=m;
        this.brojZauzetih=brojzauzetih;
        this.kontejner =null;
        this.mesta=[];
    }
    crtajParking(host){
       if(!host)
       throw new Error("Greska u hostu");
       this.kontejner=document.createElement("div");
       this.kontejner.classList.add("kontejner");
       this.kontejner.style.backgroundColor=this.tip;
       host.appendChild(this.kontejner);
       this.crtajParkingMesta(this.kontejner); 
    }
    slobodno(x,y){
      if(this.mesta[x*this.n+y].slobodno()===true)
      return true
      else 
      return false;
    }
    azurirajMesto(x,y,tablica,dani,value,povrsina,naselje){
      this.mesta[x*this.n+y].azurirajMesto(tablica,dani,value,povrsina,naselje);
         // this.brojZauzetih++;
    }
    Pronadji(tablica){
      let potencijalnaLok=this.mesta.find(mesto=>mesto.tablica==tablica);
      return potencijalnaLok;
    }
    crtajParkingMesta(host){
      const kontMesta = document.createElement("div");
      kontMesta.className="kontMesta";
      host.appendChild(kontMesta);
      //let pLabela=document.createElement("label");
      //pLabela.innerHTML=this.naselje+":";
      //kontMesta.appendChild(pLabela);
      let red;
      let mesto;
      let mest;
      for(let i=0; i<this.m;i++){
          red=document.createElement("div");
          red.className="red";
          kontMesta.appendChild(red);
          for(let j=0; j<this.n;j++){
              mest= new Mesta("",0,"",i,j,this.tip,this.naselje);
              this.dodajMesto(mest);
              mest.crtajMesto(red);   
          }
      } 
    }  
    dodajMesto(lok){
      this.mesta.push(lok);
    }
    azurirajparking(naziv,n,m,tip,broj)
    {
      this.naselje=naziv;
      this.n=n;
      this.m=m;
      this.tip=tip;
      this.brojZauzetih=broj;
      this.kontejner.innerHTML+=this.naselje;
      this.kontejner.style.backgroundColor=tip;
    }
}