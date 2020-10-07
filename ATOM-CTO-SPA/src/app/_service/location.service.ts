import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class LocationService {
  baseUrl = environment.apiURL + 'locations/';
  constructor(private http: HttpClient) {}

  getHttpHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'text/plain',
    });
  }

  saveLocation(location: any) {
    return this.http.post(this.baseUrl + 'savelocation', location);
  }

  getLocations(lat?: number, lon?: number, radius?: number) {
    let url = this.baseUrl + 'getlocations';
    if (lat != null && lon != null && radius != null) {
        url = url + '?lat=' + lat + '&lon=' + lon + '&radius=' + radius;
    }
    return this.http.get(url);
  }
}
