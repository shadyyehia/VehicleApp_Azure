node {
    try {
            stage('Checkout') 
            {
              git url: 'https://github.com/shadyyehia/VehicleApp_Azure', branch: 'master'
            }
			
            stage('Build  Web API') 
            {
                 dir("Vehicle_WebAPI") {
                    bat 'dotnet build --configuration Release'  
                 }
            }
            stage('Test  Web API') 
            {
                //bat 'dotnet test UnitTest_VehiclesWebAPI.csproj -c Release   --list-tests'  
                bat returnStatus: true, script: "dotnet test \"${workspace}/UnitTest_VehiclesWebAPI/UnitTest_VehiclesWebAPI.csproj\" --logger \"trx;LogFileName=unit_tests.xml\""
                step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
                 
            }
            stage('Deploy Web API Locally')
            {
                
                if(currentBuild.currentResult == "SUCCESS" )
                {
                    dir("Vehicle_WebAPI") {
                         bat 'dotnet publish  --framework netcoreapp2.2 -c Release -o published --no-build'  
                         echo "Published successfully"
                         //mail bcc: '', body: "<b>Example</b><br>Project: ${env.JOB_NAME} <br>Build Number: ${env.BUILD_NUMBER} <br> URL de build: ${env.BUILD_URL}", cc: '', charset: 'UTF-8', from: '', mimeType: 'text/html', replyTo: '', subject: "Build -Web API- Pass: Project name -> ${env.JOB_NAME}", to: "shady.yahia@itworx.com";  
                    }
                }
                else
                {
                    echo "Publish FAILED"
                    //mail bcc: '', body: "<b>Example</b><br>Project: ${env.JOB_NAME} <br>Build Number: ${env.BUILD_NUMBER} <br> URL de build: ${env.BUILD_URL}", cc: '', charset: 'UTF-8', from: '', mimeType: 'text/html', replyTo: '', subject: "Build - Web API- Unstable: Project name -> ${env.JOB_NAME}", to: "shady.yahia@itworx.com";  
                }
            }
			stage('Build SPA to ./dist ') 
            {
                 dir("Vehicle_ClientApp") {
                    //bat 'npm install --loglevel verbose' 
                    bat 'npm run build'  
                 }
            }
            stage('Test SPA on ./dist ') 
            {
                 dir("Vehicle_ClientApp") {
                    bat 'npm run test:unit'  
                 }
				if(currentBuild.currentResult == "SUCCESS" )
                {
					
					//mail bcc: '', body: "<b>Example</b><br>Project: ${env.JOB_NAME} <br>Build Number: ${env.BUILD_NUMBER} <br> URL de build: ${env.BUILD_URL}", cc: '', charset: 'UTF-8', from: '', mimeType: 'text/html', replyTo: '', subject: "Build -Client App- Pass: Project name -> ${env.JOB_NAME}", to: "shady.yahia@itworx.com";  
				}
				else
				{
				   //mail bcc: '', body: "<b>Example</b><br>Project: ${env.JOB_NAME} <br>Build Number: ${env.BUILD_NUMBER} <br> URL de build: ${env.BUILD_URL}", cc: '', charset: 'UTF-8', from: '', mimeType: 'text/html', replyTo: '', subject: "Build -Client App- Failed: Project name -> ${env.JOB_NAME}", to: "shady.yahia@itworx.com";  
				}
            }
           
         }
         catch (err) {
            echo "Caught: ${err}"
            currentBuild.result = 'FAILURE'
        }
   
}
