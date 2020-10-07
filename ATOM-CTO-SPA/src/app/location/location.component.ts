import { Component } from '@angular/core';
import { AlertifyService } from '../_service/alertify.service';
import { LocationService } from '../_service/location.service';
import { validationLatitudeLongitude } from 'validation-latitude-longitude';


@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css'],
})
export class LocationComponent {
  specificLocationRequired = false;
  isValidCordinates = true;
  latitude: number;
  longitude: number;
  radius: number;
  locations: [];
  showFetchLocations = false;

  constructor(
    private locationService: LocationService,
    private alertify: AlertifyService
  ) {}

  saveLocation(): void {
    this.isValidCordinates = this.validateCordinates();
    if (this.isValidCordinates) {
      const location = {
        latitude: this.latitude,
        longitude: this.longitude,
      };
      this.locationService.saveLocation(location).subscribe(
        (response: string) => {
          this.alertify.success(response);
        },
        (error) => {
          console.log(error);
          this.alertify.error(error.error);
        }
      );
    }
  }

  getLocation(): void {
    this.isValidCordinates = this.specificLocationRequired ? this.validateCordinates() : true;
    if (this.isValidCordinates) {
      this.locationService
      .getLocations(this.latitude, this.longitude, this.radius)
      .subscribe(
        (response: []) => {
          this.locations = response;
        },
        (error) => {
          console.log(error);
          this.alertify.error(error.error);
        }
      );
    }
  }

  toggleShowFetchLocations(): void {
    this.latitude = null;
    this.longitude = null;
    this.radius = null;
    this.showFetchLocations = !this.showFetchLocations;
  }
  toggleSpecificLocationOption(): void {
    this.specificLocationRequired = !this.specificLocationRequired;
    if (this.specificLocationRequired === false) {
      this.latitude = null;
      this.longitude = null;
      this.radius = null;
    }
  }

  allDataAvailable(): boolean {
    if (this.specificLocationRequired) {
      return (
        this.latitude != null && this.longitude != null && this.radius != null
      );
    } else {
      return true;
    }
  }

  validateCordinates(): boolean {
    const cordinates = [this.latitude.toString(), this.longitude.toString()];
    return validationLatitudeLongitude.latLong(...cordinates);
  }
}
