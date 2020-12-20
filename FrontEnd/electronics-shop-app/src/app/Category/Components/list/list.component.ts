import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoryService } from '../../Services/category.service';
import { GridDataResult, PageChangeEvent, GridComponent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { process, State } from '@progress/kendo-data-query';
import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private categoryService: CategoryService,
    // private paginationService: PaginationService
  ) { }


  gridView: GridDataResult;
  pageSize: number;
  pageIndex: number = 0;
  skip: number = 0;
  filter: any;

  public state: State = {
    filter: {
      logic: 'and',
      filters: []
    }
  };

  public filterSettings: DropDownFilterSettings = {
    caseSensitive: false,
    operator: 'contains'
  };


  ngOnInit() {
    // this.categoryService.getAllCategories(0,5).subscribe(result=>{
    //   console.log(result);
    // });

    this.pageSize = 5;
    // this.getList();
    this.extractRouteParams();
  }

  getList() {
    // this.postSearch.pageSize = this.pageSize;
    // this.postSearch.pageIndex = this.pageIndex;

    this.categoryService.getAllCategories(this.pageIndex, this.pageSize)
      .subscribe(res => {
        this.gridView = {
          data: res.collection,
          total: res.totalCount
        };
        console.log(res)
      },
        (error) => {
          console.log(error);
        },
      );
  }

  extractRouteParams() {
    let pageIndex = +this.route.snapshot.params['pageIndex'];
debugger;
    if (pageIndex) {
      this.pageIndex = pageIndex;
      this.skip = this.pageIndex * this.pageSize;  
      this.getList();
    }else{
      this.pageIndex = 0;
      this.getList();
    }
  }

  dataStateChange(state: DataStateChangeEvent): void {
    this.skip = state.skip;
    this.pageIndex = (this.skip / this.pageSize);
    this.state = state;
    this.filter = this.state.filter.filters;
    this.getList();
  }

  public pageChange(event: PageChangeEvent): void {
    this.pageIndex = (event.skip / this.pageSize);

    let url = [`/category/list/${this.pageIndex}`];
    this.router.navigate(url);
  }

}
