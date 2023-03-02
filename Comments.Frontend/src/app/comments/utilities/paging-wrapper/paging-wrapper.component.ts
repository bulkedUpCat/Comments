import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommentService } from '../../data-access/comment.service';

@Component({
  selector: 'paging-wrapper',
  templateUrl: './paging-wrapper.component.html',
  styleUrls: ['./paging-wrapper.component.scss']
})
export class PagingWrapperComponent implements OnInit {
  @Input() page!: number;
  @Input() pageSize!: number;
  @Input() totalPages!: number;

  constructor(
    private commentService: CommentService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    console.log(this.page, this.pageSize, this.totalPages);
  }

  onPrevPage(){
    if (this.page <= 1) return;

    this.page--;

    this.applyFiltersToRoute();
  }

  onNextPage(){
    if (this.page >= this.totalPages) return;

    this.page++;

    this.applyFiltersToRoute();
  }

  applyFiltersToRoute(){
    const queryParams: any = {};

    if (this.page) queryParams.page = this.page;

    this.router.navigate([], {
      queryParams: queryParams,
      queryParamsHandling: 'merge'
    })
  }
}
