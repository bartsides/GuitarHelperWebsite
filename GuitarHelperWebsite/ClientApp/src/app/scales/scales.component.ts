import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-scales',
  templateUrl: './scales.component.html',
})
export class ScalesComponent {
  private http: HttpClient;
  private baseUrl: string;

  public tunings: Tuning[];
  public patterns: Pattern[];
  public notes: Note[];
  public data: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    forkJoin(
      this.http.get<Pattern[]>(this.baseUrl + 'api/Pattern'),
      this.http.get<Tuning[]>(this.baseUrl + 'api/Tuning'),
      this.http.get<Note[]>(this.baseUrl + 'api/Note')
    ).subscribe(([patternData, tuningData, noteData]) => {
      this.patterns = patternData;
      this.tunings = tuningData;
      this.notes = noteData;

      this.update();
    }, error => console.error(error));
  }

  update() {
    let tuningSelect = <HTMLSelectElement>document.getElementById("tuningSelect");
    let tuning = tuningSelect ? tuningSelect.value : this.tunings[0].strings;

    let patternSelect = <HTMLSelectElement>document.getElementById("patternSelect");
    let pattern = patternSelect ? patternSelect.value : this.patterns[0].pattern;

    let noteSelect = <HTMLSelectElement>document.getElementById("noteSelect");
    let note = noteSelect ? noteSelect.value : this.notes[0].name;

    this.http.get<DrawingResult>(`${this.baseUrl}api/Drawing/${tuning}/${pattern}/${note}`).subscribe(result => {
      this.data = result.data;
    }, error => console.error(error));
  }
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

interface Tuning {
  name: string;
  strings: Note[];
  notes;
}
