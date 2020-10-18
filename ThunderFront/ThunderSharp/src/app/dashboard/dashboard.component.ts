import { Component, OnInit } from '@angular/core';
import { EChartOption } from 'echarts';
import 'echarts/src/chart/bar';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public chartOption: EChartOption;
  public idUser: number;

  constructor() { }

  ngOnInit(): void {
    this.idUser = 1;
    this.chartOption =  {
      xAxis: {
        type: 'category',
        data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
      },
      yAxis: {
        type: 'value',
      },
      series: [
        {
          data: [820, 932, 901, 934, 1290, 1330, 1320],
          type: 'bar',
        },
      ],
    };
  }
}
