import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlobService {

  constructor(private http: HttpClient) { }

  uploadBlob(containerName: string, blobName: string, formData: FormData){
    return this.http.post(environment.apiUrl + `blobs/${containerName}/${blobName}`, formData);
  }

  getBlob(containerName: string, blobName: string){
    return this.http.get(environment.apiUrl + `blobs/${containerName}/${blobName}`,
    {
      responseType: 'text'
    });
  }
}
