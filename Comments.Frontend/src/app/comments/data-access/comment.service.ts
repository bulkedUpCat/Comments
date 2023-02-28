import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentModel, CreateCommentModel } from 'src/app/models/comment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  getAllComments(): Observable<CommentModel[]>{
    return this.http.get<CommentModel[]>(environment.apiUrl + 'comments');
  }

  createComment(model: CreateCommentModel): Observable<CommentModel>{
    return this.http.post<CommentModel>(environment.apiUrl + 'comments', model);
  }
}
