import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-scale-finder',
  templateUrl: './scaleFinder.component.html'
})
export class ScaleFinderComponent {
  private http: HttpClient;
  private baseUrl: string;

  public tunings: Tuning[];
  public data: string;
  public matches: ScaleMatch[];
  public clicks: Coordinate[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.clicks = new Array();
  }

  ngOnInit() {
    this.http.get<Tuning[]>(this.baseUrl + 'api/Tuning').subscribe(result => {
      this.tunings = result;
      this.updateTuning();
    }, error => console.error(error));
  }

  updateTuning() {
    let tuning: string = this.getTuning();
    if (tuning !== null) {
      this.http.post<DrawingResult>(`${this.baseUrl}api/Drawing/`,
          JSON.stringify({ tuning: this.getTuning(), clicks: this.clicks }))
        .subscribe(result => {
          this.data = result.data;
      }, error => console.error(error));
    }
  }

  click(event: MouseEvent) {
    console.log(event.offsetX + ", " + event.offsetY);
    let tuning: string = this.getTuning();
    this.http.get<Coordinate>(`${this.baseUrl}api/Drawing/Coordinate/${tuning}/${event.offsetX}/${event.offsetY}`)
      .subscribe(result => {
        if (this.clicks.indexOf(result) > -1) {
          console.log('click removed');
          this.clicks.splice(this.clicks.indexOf(result));
        }
        else {
          console.log('click added');
          this.clicks.push(result);
        }
        this.updateTuning();
    }, error => console.error(error));
  }

  getTuning() {
    let tuningSelect = (<HTMLSelectElement>document.getElementById("tuningSelect"));

    if (tuningSelect !== null && typeof (tuningSelect) !== 'undefined') {
      return tuningSelect.value;
    }
    else if (this.tunings.length > 0) {
      return this.tunings[0].strings.toString();
    }

    return null;
  }
}

interface Coordinate {
  X: number;
  Y: number;
}

interface DrawingResult {
  data: string;
}

interface Note {
  name: string;
  value: number;
}

interface Pattern {
  name: string;
  pattern: string;
}

interface ScaleMatch {
  key: Note;
  pattern: Pattern;
  notes: Note[];
}

interface Tuning {
  name: string;
  strings: Note[];
  notes;
}
