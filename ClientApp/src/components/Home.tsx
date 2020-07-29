import React, { useState, useEffect } from 'react';
import { DetailsList, SelectionMode, DetailsListLayoutMode, IColumn } from 'office-ui-fabric-react/lib/DetailsList';

const columns: IColumn[] = [
  {
      key: 'name', name: 'Name', fieldName: 'name', minWidth: 200, maxWidth: 300, isRowHeader: true,
      isResizable: true, isSorted: false, isSortedDescending: false, 
  },
  {
      key: 'syncFrequency', name: 'Sync Frequency', fieldName: 'syncFrequency', minWidth: 100, maxWidth: 150,
      isResizable: true, isMultiline: true
  },
  {
      key: 'sourceUrl', name: 'Source Url', fieldName: 'sourceUrl', minWidth: 100, maxWidth: 150,
      isResizable: true, 
  },
  {
      key: 'destinationPath', name: 'Destination Path', fieldName: 'destinationPath', minWidth: 100,
      maxWidth: 150, isResizable: true, 
  },
  {
      key: 'destinationRepository', name: 'Destination Repository', fieldName: 'destinationRepository', minWidth: 75, maxWidth: 150,
      isResizable: true, 
  },
  {
      key: 'status', name: 'Status', fieldName: 'status', minWidth: 75, maxWidth: 100,
      isResizable: true, 
  },
  {
      key: 'lastRun', name: 'LastRun', fieldName: 'lastRun', minWidth: 75, maxWidth: 100,
      isResizable: true, 
  }
];

function Home () {
  const [items,setItems] = useState([]);
  
  useEffect(() => {
    fetch('job')
      .then((response) => {
        response.json()
          .then( (json) => {
            setItems(json);
          })
      })
      .catch((error) => {
        console.log(error)
      });
  }, []);

  return (
    <div>
      <h1>Jobs</h1>
      <DetailsList
          items={items}
          selectionMode={SelectionMode.none}
          layoutMode={DetailsListLayoutMode.justified}
          columns={columns} 
        />
    </div>
  );
}

export default Home;