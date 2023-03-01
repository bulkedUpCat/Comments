import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentModel, CreateCommentModel, GetCommentsModel, PagedCommentList, UpdateCommentModel } from 'src/app/models/comment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  getAllComments(model: GetCommentsModel): Observable<PagedCommentList>{
    var queryParams: any = [];

    if (model.sort) queryParams['sort'] = model.sort;
    if (model.sortOrder) queryParams['sortOrder'] = model.sortOrder;

    return this.http.get<PagedCommentList>(environment.apiUrl + 'comments', {
      params: queryParams
    });
  }

  getAllReplies(parentCommentId: string): Observable<CommentModel[]>{
    return this.http.get<CommentModel[]>(environment.apiUrl + parentCommentId + '/replies');
  }

  createComment(model: CreateCommentModel): Observable<CommentModel>{
    return this.http.post<CommentModel>(environment.apiUrl + 'comments', model);
  }

  uploadAttachment(id: string, file: FormData){
    return this.http.post(environment.apiUrl + 'comments/' + id + '/attachment', file);
  }

  updateComment(model: UpdateCommentModel){
    return this.http.put(environment.apiUrl + 'comments', model);
  }

  deleteComment(id: string){
    return this.http.delete(environment.apiUrl + 'comments/' + id);
  }
}
