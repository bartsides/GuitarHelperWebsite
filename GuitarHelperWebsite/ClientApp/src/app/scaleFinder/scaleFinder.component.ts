import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-scaleFinder',
  templateUrl: './scaleFinder.component.html'
})
export class ScaleFinderComponent {
  private http: HttpClient;
  private baseUrl: string;

  public tunings: Tuning[];
  public data: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

    http.get<Tuning[]>(baseUrl + 'api/Tuning').subscribe(result => {
      this.tunings = result;
      this.updateTuning();
    }, error => console.error(error));
  }

  updateTuning() {
    let tuningSelect = (<HTMLSelectElement>document.getElementById("tuningSelect"));
    if (typeof (tuningSelect) === 'undefined' || tuningSelect === null)
      return;
    let tuning = tuningSelect.value;

    if (tuning === "" && typeof(this.tunings) !== 'undefined') {
      tuning = this.tunings[0].strings.toString();
    }

    if (tuning !== "") {
      this.http.get<DrawingResult>(`${this.baseUrl}api/Drawing/${tuning}`).subscribe(result => {
        this.data = result.data;
      }, error => console.error(error));
    }
  }

  click(event: MouseEvent) {
    console.log(event.offsetX + ", " + event.offsetY);
  }
}

interface Note {
  name: string;
  value: number;
}

interface Tuning {
  name: string;
  strings: Note[];
  notes;
}

interface DrawingResult {
  data: string;
}
