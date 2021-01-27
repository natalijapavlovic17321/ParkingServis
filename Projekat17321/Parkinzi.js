import {Parking} from "./Parking.js"
export class Parkinzi{
    constructor(id,naziv,num,n,m)
    {
        this.id = id;
        this.naziv=naziv;
        this.num=num;
        this.Megakontejner =null;
        this.povrsine=[];
        this.n=n;
        this.m=m;
    }
    crtajPark(host){
       if(!host)
       throw new Error("Greska u hostu");
       
       this.Megakontejner=document.createElement("div");
       this.Megakontejner.classList.add("Megakontejner");
       host.appendChild(this.Megakontejner);
       this.crtajFormuParkiraj(this.Megakontejner);
       this.crtajParkingPovrsine(this.Megakontejner);
    }
    crtajParkingPovrsine(host){
        const kontPovrsine = document.createElement("div");
        kontPovrsine.className="kontPovrsine";
        kontPovrsine.innerHTML=this.naziv;
        host.appendChild(kontPovrsine);
        let red;
        let pov;
        for(let i=0; i<this.num;i++){
            red=document.createElement("div");
            red.className="red";
            kontPovrsine.appendChild(red);
            pov=new Parking("",this.n,this.m,"",0);
            this.dodajParking(pov);
            pov.crtajParking(red); 
        } 
      }  
    crtajFormuParkiraj(host){
        const kont1=document.createElement("div");
        kont1.className="kontParkiraj";
        host.appendChild(kont1);
  
        var pLabela=document.createElement("h3");
        pLabela.innerHTML="Unesite podatke vozila";
        kont1.appendChild(pLabela);
  
        pLabela=document.createElement("label");
        pLabela.innerHTML="Broj tablice:";
        kont1.appendChild(pLabela);
  
        pLabela=document.createElement("input");
        pLabela.className="Brtablice";
        kont1.appendChild(pLabela);
  
        pLabela=document.createElement("label");
        pLabela.innerHTML="Broj dana:";
        kont1.appendChild(pLabela);
  
        pLabela= document.createElement("input");
        pLabela.className="Brojdana";
        pLabela.type="number";
        kont1.appendChild(pLabela);
  
        pLabela=document.createElement("label");
        pLabela.innerHTML="Vrsta vozila:";
        kont1.appendChild(pLabela);
  
        let tipoviVozila =["auto", "kamion", "motor"];
        let zauzeto =["red","pink","brown"];
        let opcija=null;
        let labela=null;
        let divRb=null;
        tipoviVozila.forEach((vozila,index)=>{
            divRb = document.createElement("div");
            opcija = document.createElement("input");
            opcija.type="radio";
            opcija.name = "radiovozila";
            opcija.value= zauzeto[index];
  
            labela = document.createElement("label");
            labela.innerHTML=vozila;
            divRb.appendChild(opcija);
            divRb.appendChild(labela);
            kont1.appendChild(divRb);
        })

        pLabela=document.createElement("label");
        pLabela.innerHTML="Parking povrsina:";
        kont1.appendChild(pLabela);

        let tipoviPovrsina =["voda", "trava", "beton"];
        let tipoviBoja =["blue", "green", "gray"];
        opcija=null;
        labela=null;
        divRb=null;
        tipoviPovrsina.forEach((povrsina, index)=>{
            divRb = document.createElement("div");
            opcija = document.createElement("input");
            opcija.type="radio";
            opcija.name = this.naziv;
            opcija.value= tipoviBoja[index];
  
            labela = document.createElement("label");
            labela.innerHTML=povrsina;
            divRb.appendChild(opcija);
            divRb.appendChild(labela);
            kont1.appendChild(divRb);
        })
        pLabela=document.createElement("label");
        pLabela.innerHTML="U kom naselju:";
        kont1.appendChild(pLabela);

        pLabela=document.createElement("input");
        pLabela.className="Naselje";
        kont1.appendChild(pLabela);

        pLabela=document.createElement("label");
        pLabela.innerHTML="Parking mesto:";
        kont1.appendChild(pLabela);
    
        divRb = document.createElement("div");
        let selY= document.createElement("select");
        let selX= document.createElement("select");
        this.dodajOpcije(this.m,"Red",kont1,divRb,selX)
        this.dodajOpcije(this.n,"Mesto",kont1,divRb,selY);
  
        this.dodajDugme(kont1,"Parkiraj",selX,selY);
        this.dodajDugme(kont1,"Produzi",selX,selY);
        var pLabela=document.createElement("h3");
        pLabela.innerHTML="Unesite tablicu da bi odparkirali";
        kont1.appendChild(pLabela);
        pLabela=document.createElement("input");
        pLabela.className="Brojtablice";
        kont1.appendChild(pLabela);

        this.dodajDugme(kont1,"Odparkiraj",selX,selY);
  
      }
       
    dodajDugme(host,text,selX,selY){
        const dugme = document.createElement("button");
        dugme.innerHTML=text;
        host.appendChild(dugme);
        dugme.onclick=(ev)=>{
        if(text=="Parkiraj")
        {
          const tablica= this.Megakontejner.querySelector(".Brtablice").value;
          const dani = parseInt(this.Megakontejner.querySelector(".Brojdana").value);
          const vozilo = this.Megakontejner.querySelector(`input[name='${"radiovozila"}']:checked`);
          const tipparking = this.Megakontejner.querySelector(`input[name='${this.naziv}']:checked`);
          const naselje=this.Megakontejner.querySelector(".Naselje").value;
          if(vozilo==null)
          {
                  alert("Molimo Vas odaberite vrstu vozila");
                  return;
          }
          if(tipparking==null)
          {
                  alert("Molimo Vas odaberite vrstu povrsine"); 
                  return;
          }
          if( tablica=="" || tablica.length!=9)   
          {
                  alert("Uneti ispravan broj vozacke. Ne sme biti prazno. Vozacka sadrzi 9 karaktera( XY NNN ZW)");
                  return;
          }
          if(!this.Megakontejner.querySelector(".Brojdana").value)
          {
            alert("Molimo Vas odaberite vrednost dana");
            return; 
          }
          if(!naselje)
          {
            alert("Unesite vrednost naselja");
            return;
          }
          let t;
          this.povrsine.forEach(povrsina=>{ 
              if(povrsina.naselje==naselje && povrsina.tip==tipparking.value)
                 t=true;
          })
          if(t!=true)
          {
             alert("Napisite ispravan naziv naselja i ispravan tip parking povrsine");
             return;
          }
          let x = parseInt(selX.value);
          let y = parseInt(selY.value);
          fetch("https://localhost:5001/Parkinzi/UpisMesta/" + this.id, {
                method: "POST",
                headers: {
                   "Content-Type": "application/json"
                },
                body: JSON.stringify({
                  //id: id,
                  tablica: tablica,
                  dani: dani,
                  x: x,
                  y: y,
                  tip: vozilo.value,
                  povrsina: tipparking.value,
                  naselje: naselje
                })
            }).then(p => {
                if (p.ok) {
                    let povrsina=this.povrsine.find(mesto=>mesto.tip==tipparking.value && mesto.naselje==naselje);
                    povrsina.azurirajMesto(x,y,tablica,dani,vozilo.value,tipparking.value,naselje);
                    location .reload();
                }
                else if (p.status == 400) {
                    const greskaLokacija = { x: 0, y: 0 };
                    p.json().then(q => {
                        greskaLokacija.x = q.x;
                        greskaLokacija.y = q.y;
                        alert("Postoji lokacija sa navedenom tablicom! Lokacija je (" + greskaLokacija.x + "," + greskaLokacija.y + ")");
                    });
                }
                else {
                    alert("Ta lokacija je vec zauzeta.");
                }
            }).catch(p => {
                alert("Greška prilikom upisa.");
            });
        }
        else 
        { 
          if(text=="Produzi"){
            const tablica= this.Megakontejner.querySelector(".Brtablice").value;
            const dani = parseInt(this.Megakontejner.querySelector(".Brojdana").value);
            let beforeMem=this.PronadjiLokaciju(tablica);
            if(beforeMem==null){
            alert("Ne postoji lokacija sa tom tablicom");
            return;
          }
          if( tablica=="" || tablica.length!=9)   
          {
                  alert("Uneti ispravan broj vozacke. Ne sme biti prazno. Vozacka sadrzi 9 karaktera( XY NNN ZW)");
                  return;
          }
          if(!this.Megakontejner.querySelector(".Brojdana").value)
          {
            alert("Molimo Vas odaberite vrednost dana");
            return; 
          }
            beforeMem.dani+=dani;
            console.log(beforeMem.dani);
            fetch("https://localhost:5001/Parkinzi/IzmeniMesta", {
              method: "PUT",
              headers: {
                 "Content-Type": "application/json"
              },
              body: JSON.stringify({
                //id: id,
                tablica: beforeMem.tablica,
                dani: beforeMem.dani,
                x: beforeMem.x,
                y: beforeMem.y,
                tip: beforeMem.tip,
                povrsina: beforeMem.povrsina,
                naselje: beforeMem.naselje
              })
          }).then(p => { //obrisi mesto iz ove liste
              if (p.ok) {
                  beforeMem.azurirajMesto(beforeMem.tablica,beforeMem.dani,beforeMem.tip,beforeMem.povrsina,beforeMem.naselje);
                  location.reload();
              }
              else {
                  alert("Greska.");
              }
          }).catch(p => {
              alert("Greška. Pokusajte ponovo");
          });
          }
          else{
          const odparkiranje= this.Megakontejner.querySelector(".Brojtablice").value;
          if( odparkiranje=="" || odparkiranje.length!=9)   
          {
                  alert("Uneti ispravan broj vozacke. Ne sme biti prazno. Vozacka sadrzi 9 karaktera( XY NNN ZW)");
                  return;
          }
          //let potencijalnoMesto=this.PronadjiLokaciju(odparkiranje);
          /*if(!potencijalnoMesto)
          {
            alert("Ne postoji mesto s tom tablicom");
            return;
          }*/
          fetch("https://localhost:5001/Parkinzi/PreuzmiMesto/" + odparkiranje, {
              method: "GET",
                headers: {
                  "Content-Type": "application/json"
                }
          }).then(p => {
            if (p.ok) { 
                  p.json().then(data=>{
                    alert("Otparkirano je sledece vozilo:\n"+ data.tablica +"\nsa naselja: "+data.naselje+" (x,y)=("+data.x+","+data.y+").");
                  });
            }
            else {
              alert("Ne postoji to vozilo.");
            }
            }).catch(p => {
                alert("Greška prilikom citanja.");
            });
            let potencijalnoMesto=this.PronadjiLokaciju(odparkiranje);
          fetch("https://localhost:5001/Parkinzi/IzbrisiMesto/" + odparkiranje, {
              method: "DELETE",
                headers: {
                  "Content-Type": "application/json"
                }
          }).then(p => {
            if (p.ok) {
                  potencijalnoMesto.ObrisiMesto();
                  location.reload();
            }
            else {
              alert("Greska.");
            }
            }).catch(p => {
                alert("Greška prilikom brisanja.");
            });
          }
        }
        
        /*if(text==="Parkiraj"){
          let potencijalnoMesto=this.PronadjiLokaciju(tablica);
          if(potencijalnoMesto)
          alert("Postoji parking mesto sa zadatom tablicom. Lokacija je ("+potencijalnoMesto.x+","+potencijalnoMesto.y+") na "+ potencijalnoMesto.povrsina+" povrsini.");
          else{
              let povrsina=this.povrsine.find(mesto=>mesto.tip==tipparking.value);
              if(povrsina==null)
                  alert("Ne postoji takav parking");
             else{ if(povrsina.brojzauzetih==this.n*this.m)
              alert("Nema vise mesta na parkingu");
              else //{while(!povrsina.slobodno(x,y))
                   //{
                    //povrsina=this.povrsine.find(mesto=>mesto.tip==tipparking.value&& mesto!==povrsina);
                  // }
                  {for(let i=0;i<this.num;i++)
                    {
                      if(this.povrsine[i].tip===tipparking.value && this.povrsine[i].slobodno(x,y))
                        {
                          povrsina=this.povrsine[i];
                          break;
                        }
                    }
                   console.log(povrsina);
                   povrsina.azurirajMesto(x,y,tablica,dani,vozilo.value,tipparking.value);
                }
             }
          } 
        }
        else {
          let potencijalnoMesto=this.PronadjiLokaciju(odparkiranje);
          if(!potencijalnoMesto)
          alert("Ne postoji vozilo sa takvom tablicom");
          else {
          potencijalnoMesto.ObrisiMesto();
          }
        }*/
        }
      }
      dodajParking(pov){
        this.povrsine.push(pov);
      }
      dodajOpcije(number,name,host,divRb,sel){
        let labela = document.createElement("label");
        labela.innerHTML=name
        divRb.appendChild(labela);
        divRb.appendChild(sel);
        for(let i=0; i<number;i++){
            let opcija=document.createElement("option");
            opcija.innerHTML=i;
            opcija.value=i;
            sel.appendChild(opcija);
        }
        host.appendChild(divRb);
      }
      PronadjiLokaciju(tablica){
        let potencijalnoMesto;
        for(let i=0;i<this.num;i++) {
            let potencijalnomesto=this.povrsine[i].Pronadji(tablica);
            if(potencijalnomesto)
               potencijalnoMesto=potencijalnomesto;
      }
      return potencijalnoMesto;
    }

}