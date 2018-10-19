import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private http: HttpClient;
  private baseUrl: string;

  public tunings: Tuning[];
  public patterns: Pattern[];
  public notes: Note[];
  public data: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

    http.get<Pattern[]>(baseUrl + 'api/Pattern').subscribe(result => {
      this.patterns = result;
    }, error => console.error(error));

    http.get<Tuning[]>(baseUrl + 'api/Tuning').subscribe(result => {
      this.tunings = result;
    }, error => console.error(error));

    http.get<Note[]>(baseUrl + 'api/Note').subscribe(result => {
      this.notes = result;
    }, error => console.error(error));
  }

  update() {
    let tuning = (<HTMLSelectElement>document.getElementById("tuningSelect")).value;
    let pattern = (<HTMLSelectElement>document.getElementById("patternSelect")).value;
    let note = (<HTMLSelectElement>document.getElementById("noteSelect")).value;

    this.http.get<DrawingResult>(`${this.baseUrl}api/Drawing/${tuning}/${pattern}/${note}`).subscribe(result => {
      this.data = result.data;
      console.log('result: ' + result.data);
    }, error => console.error(error));
  }
}

interface Tuning {
  name: string;
  strings: Note[];
  notes;
}

interface Pattern {
  name: string;
  pattern: string;
}

interface Note {
  name: string;
  value: number;
}

interface DrawingResult {
  data: string;
}
