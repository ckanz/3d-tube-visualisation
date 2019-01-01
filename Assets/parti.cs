using UnityEngine;
using System.Collections;

public class parti : MonoBehaviour
{

	private int resolution = 3000;
	private ParticleSystem.Particle[] stationColor;
	GameObject[] positions;
	bool on = false;
	string[,] content;
	public Vector3 up = new Vector3 (0, 2000, 0);
	string[] bakerloo;
	string[] victoria;
	string[] hamersmith;
	string[] piccadilly;
	string[] central;
	string[] jubilee;
	string[] circle;
	string[] district;
	string[] metropolitan;
	string[] northern;
	string[] overground;
	string[] dlr;
	
	void Start ()
	{
		
		bakerloo = new string [] {"Elephant & Castle","Lambeth North","Waterloo","Embankment","Charing Cross","Piccadilly Circus","Oxford Circus","Regent's Park","Baker Street","Marylebone","Edgware Road","Paddington","Warwick Avenue","Maida Vale","Kilburn Park","Queen's Park","Kensal Green","Willesden Junction","Harlesden","Stonebridge Park","Wembley Central","North Wembley","South Kenton","Kenton","Harrow & Wealdstone"};
		central = new string [] {"Epping","Theydon Bois","Debden","Loughton","Buckhurst Hill","Grange Hill","Chigwell","Roding Valley","Woodford","South Woodford","Snaresbrook","Hainault","Fairlop","Barkingside","Newbury Park","Gants Hill","Redbridge","Wanstead","Leytonstone","Leyton","Stratford","Mile End","Bethnal Green","Liverpool Street","Bank","St.Paul's","Chancery Lane","Holborn","Tottenham Court Road","Oxford Circus","Bond Street","Marble Arch","Lancaster Gate","Queensway","Notting Hill Gate","Holland Park","Shepherd's Bush","White City","East Acton","North Acton","West Acton","Ealing Broadway","Hanger Lane","Perivale","Greenford","Northolt","South Ruislip","Ruislip Gardens","West Ruislip"};
		hamersmith = new string [] {"Hammersmith","Goldhawk Road","Shepherd's Bush","Latimer Road","Ladbroke Grove","Westbourne Park","Royal Oak","Paddington","Edgware Road","Baker Street","Great Portland Street","Euston Square","King's Cross","Farringdon","Barbican","Moorgate","Liverpool Street","Aldgate","Tower Hill","Aldgate East","Whitechapel"};
		circle = new string [] {"Tower Hill","Aldgate","Liverpool Street","Moorgate","Barbican","Farringdon","King's Cross","Euston Square","Great Portland Street","Baker Street","Edgware Road","Paddington","Bayswater","Notting Hill Gate","High Street Kensington","Gloucester Road","South Kensington","Sloane Square","Victoria","St.James's Park","Westminster","Embankment","Temple","Blackfriars","Mansion House","Cannon Street","Monument"};
		district = new string [] {"Upminster","Upminster Bridge","Hornchurch","Elm Park","Dagenham East","Dagenham Heathway","Becontree","Upney","Barking","East Ham","Upton Park","Plaistow","West Ham","Bromley-by-Bow","Bow Road","Mile End","Stepney Green","Whitechapel","Aldgate East","Tower Hill","Monument","Cannon Street","Mansion House","Blackfriars","Temple","Embankment","Westminster","St. James's Park","Victoria","Sloane Square","South Kensington","Gloucester Road","High Street Ken.","Earl's Court","West Brompton","Fulham Broadway","Parsons Green","Putney Bridge","East Putney","Southfields","Wimbledon Park","Wimbledon","West Kensington","Barons Court","Hammersmith","Ravenscourt Park","Stamford Brook","Turnham Green","Gunnersbury","Kew Gardens","Richmond","Chiswick Park","Acton Town","Ealing Common","Ealing Broadway"};
		jubilee = new string [] {"Stanmore","Canons Park","Queensbury","Kingsbury","Wembley Park","Neasden","Dollis Hill","Willesden Green","Kilburn","West Hampstead","Finchley Road","Swiss Cottage","St.John's Wood","Baker Street","Bond Street","Green Park","Westminister","Waterloo","Southwark","London Bridge","Bermondsy","Canada Water","Canary Wharf","Canning Town","West Ham","Stratford"};
		metropolitan = new string [] {"Aldgate","Liverpool Street","Moorgate","Barbican","Farringdon","King's Cross","Euston Square","Great Portland Street","Baker Street","Finchley Road","Wembley Park","Preston Road","Northwick Park","Marylebone","Harrow-on-the-hill","West Harrow","Rayners Lane","Eastcote","Ruislip Manor","Ruislip","Ickenham","Hillingdon","Uxbridge","North Harrow","Pinner","Northwood Hills","Northwood","Moor Park","Croxley","Watford","Rickmansworth","Chorleywood","Chalfont Latimer","Chesham","Amersham"};
		northern = new string [] {"Morden","South Wimbledon","Colliers Wood","Tooting Broadway","Tooting Bec","Balham","Clapham South","Clapham Common","Clapham North","Stockwell","Oval","Kennington","Elephant Castle","Borough","London Bridge","Bank","Moorgate","Old Street","Angel","King's Cross","Waterloo","Embankment","Charing Cross","Leicester Square","Tottenham Court Road","Goodge Street","Warren Street","Euston","Mornington Crescent","Camden town","Kentish Town","Tufnell Park","Archway","Highgate","East Finchley","Finchley Central","Mill Hill East","West Finchley","Woodside Park","Totteridge","Hiigh Barnet","Chalk Farm","Belsize Park","Hampstead","Golders Green","Brent Cross","Hendon Central","Colindale","Burnt Oak","Edgeware"};
		piccadilly = new string [] {"Cockfosters","Oakwood","Southgate","Arnos Grove","Bounds Green","Wood Green","Turnpike Lane","Manor House","Finsbury Park","Arsenal","Holloway Road","Caledonian Road","King's Cross","Russell Square","Holborn","Covent Garden","Leicester Square","Piccadilly Circus","Green Park","Hyde Park Corner","Knightsbridge","South Kensington","Gloucester Road","Earl's Court","Barons Court","Hammersmith","Acton Town","South Ealing","Northfields","Boston Manor","Osterley","Hounslow East","Hounslow Central","Hounslow West","Hatton Cross","Heathrow Terminal 4","Heathrow Terminals 1, 2, 3","Ealing Common","North Ealing","Park Royal","Alperton","Sudbury Town","Sudbury Hill","South Harrow","Rayners Lane"};
		victoria = new string [] {"Brixton","Stockwell","Vauxhall","Pimlico","Victoria","Green Park","Oxford Circus","Warren Street","Euston","King's Cross","Highbury & Islington","Finsbury Park","Seven Sisters","Tottenham Hale","Blackhorse Road","Walthamstow Central"};
		overground = new string [] {"Richmond ","Kew Gardens","Gunnersbury","South Acton ","Acton Central ","Willesden Junction","Kensal Rise","Brondesbury Park","Brondesbury","West Hampstead ","Finchley Road & Frognal","Hampstead Heath","Gospel Oak","Kentish Town West","Camden Road","Caledonian Road & Barnsbury","Highbury & Islington ","Canonbury ","Dalston Kingsland","Hackney Central","Homerton ","Hackney Wick","Stratford","Willesden Junction ","Shepherd's Bush ","Kensington (Olympia)","West Brompton ","Imperial Wharf ","Clapham Junction","Highbury & Islington ","Canonbury ","Dalston Junction","Haggerston ","Hoxton ","Shoreditch High Street ","Whitechapel","Shadwell","Wapping","Rotherhithe","Canada Water","Surrey Quays","New Cross","New Cross Gate","Brockley ","Honor Oak Park ","Forest Hill ","Sydenham National","Crystal Palace","Penge West ","Anerley","Norwood Junction","West Croydon Tramlink ","Surrey Quays","Queens Road Peckham","Peckham Rye ","Denmark Hill","Clapham High Street","Wandsworth Road","Clapham Junction ","Battersea Park","Euston ","South Hampstead","Kilburn High Road","Queen's Park","Kensal Green","Willesden Junction","Harlesden ","Stonebridge Park ","Wembley Central ","North Wembley ","South Kenton ","Kenton ","Harrow & Wealdstone","Headstone Lane","Hatch End","Carpenders Park ","Bushey National Rail","Watford High Street","Watford Junction ","Gospel Oak","Upper Holloway","Crouch Hill","Harringay Green Lanes","South Tottenham","Blackhorse Road ","Walthamstow Queen's Road","Leyton Midland Road","Leytonstone High Road","Wanstead Park","Woodgrange Park","Barking"};
		dlr = new string [] {"Abbey Road","All Saints","Bank","Beckton","Beckton Park","Blackwall","Bow Church","Canary Wharf","Canning Town","Crossharbour","Custom House","Cutty Sark","for Maritime Greenwich","Cyprus","Deptford Bridge","Devons Road","East India","Elverson Road","Gallions Reach","Greenwich","Heron Quays","Island Gardens","King George V","Langdon Park","Lewisham","Limehouse","London City Airport","Mudchute","Pontoon Dock","Poplar","Prince Regent","Pudding Mill Lane","Royal Albert","Royal Victoria","Shadwell","South Quay","Star Lane","Stratford","Stratford","Stratford High Street","Stratford International","Tower Gateway","West Ham","West India Quay","West Silvertown","Westferry","Woolwich Arsenal"};
		
		stationColor = new ParticleSystem.Particle[resolution];
		content = CSVReader.grid;
		positions = CSVReader.Stations;
		
		

		for (int i=1; i<resolution; i++) {
			stationColor [i].position = positions [i].transform.position+up;
			//stationColor[i].color = new Color (1.0F, 1.0F, 1.0F);
			foreach (string x in overground) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.8F, 0.7F, 0.4F);
				}
			}
			foreach (string x in dlr) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.5F, 0.5F, 1.0F);
				}	
    		
			}
			foreach (string x in victoria) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.0F, 1.0F, 1.0F);
				}	
			}
			foreach (string x in piccadilly) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.0F, 0.0F, 1.0F);
				}	
			}
			foreach (string x in metropolitan) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (1.0F, 0.0F, 0.0F);
				}	
			}
			foreach (string x in northern) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.0F, 0.0F, 0.0F);
				}	
			}
			foreach (string x in district) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.0F, 1.0F, 0.0F);
				}	
			}
			foreach (string x in hamersmith) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.7F, 0.0F, 0.5F);
				}	
			}	
			foreach (string x in jubilee) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.2F, 0.2F, 0.2F);
				}	
			}
			foreach (string x in circle) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (1.0F, 1.0F, 0.0F);
				}	
			}
			foreach (string x in bakerloo) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (0.8F, 0.3F, 0.0F);
				}	
			}
			foreach (string x in central) {
				if (x.Contains (content [0, i])) {
					stationColor [i].color = new Color (1.0F, 0.0F, 0.0F);
				}	
			}

		
			
			stationColor [i].size = 5.1f;	
			

			
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CSVReader.lineToggle == true && on == false) {
			showpoints ();
			particleSystem.SetParticles (stationColor, stationColor.Length);
			on = true;
		}
		if (CSVReader.lineToggle == false && on == true) {
			hidepoints ();
			particleSystem.SetParticles (stationColor, stationColor.Length);
			on = false;
		}
	}
	
	void showpoints ()
	{
		content = CSVReader.grid;
		for (int i=5; i<resolution; i++) {
			//points[i].size = 10F;
			stationColor [i].position = stationColor [i].position - up;
		}
		
	}
	
	void hidepoints ()
	{
		//particleSystem.Clear();
		for (int i=1; i<resolution; i++) {
			stationColor [i].position = stationColor [i].position + up;
		}
		
	}

}
