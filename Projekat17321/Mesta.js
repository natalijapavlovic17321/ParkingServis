export class Mesta {
    constructor(tablica,dani,tip,x,y,povrsina,naselje){
        this.tablica=tablica;
        this.dani=dani;
        this.x=x;
        this.y=y;
        this.tip=tip;
        this.miniKontejner=null;
        this.povrsina=povrsina;
        this.naselje=naselje
    }
    crtajMesto(host){
        this.miniKontejner = document.createElement("div");
        this.miniKontejner.className="mes";
        this.miniKontejner.innerHTML="Free";
        this.miniKontejner.style.backgroundColor=this.vratiBoju();
        host.appendChild(this.miniKontejner);
    }
    ObrisiMesto()
    {
        this.tablica="";
        this.dani=null
        this.miniKontejner.innerHTML="Free";
        this.miniKontejner.style.backgroundColor=this.povrsina;
    }
    azurirajMesto(tablica,dani,value,povrsina,naselje){
        if(this.tablica=="")
        {
        this.tablica=tablica;
        this.dani=dani;
        this.tip=value;
        this.povrsina=povrsina;
        this.naselje=naselje;
        this.miniKontejner.innerHTML = tablica+", "+dani ;
        this.miniKontejner.style.backgroundColor=value;
        }
        else alert("Vozilo " + this.tablica+ " je ovde parkirano");
    }
    vratiBoju(){
        if(!this.tip)
        return this.povrsina;
        else
        return this.tip;
    }
    slobodno(){
        if(this.tablica=="")
        return true;
        else
        return false;
    }
}